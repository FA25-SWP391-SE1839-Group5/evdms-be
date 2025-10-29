using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using EVDMS.BusinessLogicLayer.Services.Interfaces;
using EVDMS.Common.Dtos;
using EVDMS.Common.Enums;
using EVDMS.Common.Utils;
using EVDMS.DataAccessLayer.Entities;
using EVDMS.DataAccessLayer.Repositories.Interfaces;

namespace EVDMS.BusinessLogicLayer.Services.Implementations
{
    public class UserService
        : BaseService<User, UserDto, CreateUserDto, UpdateUserDto, PatchUserDto>,
            IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IDealerRepository _dealerRepository;
        private readonly IEmailService _emailService;
        private readonly IAuditLogService _auditLogService;

        public UserService(
            IUserRepository userRepository,
            IDealerRepository dealerRepository,
            IMapper mapper,
            IEmailService emailService,
            IAuditLogService auditLogService
        )
            : base(userRepository, mapper)
        {
            _userRepository = userRepository;
            _dealerRepository = dealerRepository;
            _emailService = emailService;
            _auditLogService = auditLogService;
        }

        public async Task<UserDto> CreateAsync(CreateUserDto dto, UserRole currentUserRole)
        {
            if (currentUserRole == UserRole.Admin) { }
            else if (currentUserRole == UserRole.DealerManager)
            {
                if (dto.Role != UserRole.DealerStaff)
                    throw new UnauthorizedAccessException(
                        "Dealer managers can only create Dealer Staff users."
                    );
            }
            else
            {
                throw new UnauthorizedAccessException("You are not allowed to create users.");
            }

            if (dto.DealerId != null)
            {
                var dealer = await _dealerRepository.GetByIdAsync(dto.DealerId.Value);
                if (dealer == null)
                    throw new KeyNotFoundException("Dealer not found.");
                if (dto.Role != UserRole.DealerStaff && dto.Role != UserRole.DealerManager)
                    throw new InvalidOperationException(
                        "If DealerId is provided, role must be DealerStaff or DealerManager."
                    );
            }
            else
            {
                if (dto.Role != UserRole.EvmStaff && dto.Role != UserRole.Admin)
                    throw new InvalidOperationException(
                        "If DealerId is null, role must be EvmStaff or Admin."
                    );
            }

            // Basic syntax check and MX/A record verification to reduce fake emails
            if (!EmailVerifier.IsValidFormat(dto.Email))
                throw new ArgumentException("The provided email address has an invalid format.");

            var domainIsValid = await EmailVerifier.DomainHasMailServerAsync(dto.Email);
            if (!domainIsValid)
                throw new ArgumentException(
                    "The email domain does not appear to accept mail (no MX/A records)."
                );

            if (EmailVerifier.IsDisposableDomain(dto.Email))
                throw new ArgumentException(
                    "Disposable or temporary email addresses are not allowed."
                );

            if (await _userRepository.ExistsByEmailAsync(dto.Email))
                throw new InvalidOperationException(
                    $"A user with email '{dto.Email}' already exists."
                );

            var tempPassword = GenerateTemporaryPassword();
            var passwordHash = PasswordHasher.HashPassword(tempPassword);

            var user = _mapper.Map<User>(dto);
            user.PasswordHash = passwordHash;

            await _userRepository.AddAsync(user);
            await _userRepository.SaveChangesAsync();

            // Log account creation
            await _auditLogService.CreateAsync(
                new CreateAuditLogDto
                {
                    UserId = user.Id,
                    Action = AuditLogAction.AccountCreation,
                    Description = $"User {user.Email} account created.",
                }
            );

            var subject = "Your Account Has Been Created";
            var templatePath = Path.Combine(
                AppContext.BaseDirectory,
                "EmailTemplates",
                "AccountCreated.html"
            );

            string body;
            if (File.Exists(templatePath))
            {
                body = await File.ReadAllTextAsync(templatePath);
                body = body.Replace("{FullName}", user.FullName)
                    .Replace("{TempPassword}", tempPassword)
                    .Replace("{Year}", DateTime.UtcNow.Year.ToString());
            }
            else
            {
                body =
                    $"Hello {user.FullName}, your account has been created. Your temporary password is: {tempPassword}";
            }

            await _emailService.SendEmailAsync(user.Email, subject, body);
            return _mapper.Map<UserDto>(user);
        }

        private static string GenerateTemporaryPassword(int length = 12)
        {
            const string valid =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*()";
            var res = new StringBuilder();
            using (var rng = RandomNumberGenerator.Create())
            {
                var uintBuffer = new byte[sizeof(uint)];
                while (res.Length < length)
                {
                    rng.GetBytes(uintBuffer);
                    var num = BitConverter.ToUInt32(uintBuffer, 0);
                    res.Append(valid[(int)(num % (uint)valid.Length)]);
                }
            }
            return res.ToString();
        }

        public async Task<UserDto?> GetCurrentUserAsync(Guid userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
                return null;
            return _mapper.Map<UserDto>(user);
        }

        public override async Task<bool> DeleteAsync(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
                return false;
            await base.DeleteAsync(id);

            // Log account deletion
            await _auditLogService.CreateAsync(
                new CreateAuditLogDto
                {
                    UserId = user.Id,
                    Action = AuditLogAction.AccountDeletion,
                    Description = $"User {user.Email} account deleted.",
                }
            );

            return true;
        }

        public override async Task<PaginatedResult<UserDto>> GetAllAsync(
            int page,
            int pageSize,
            string? sortBy = null,
            string? sortOrder = null,
            string? search = null,
            Dictionary<string, string>? filters = null,
            IEnumerable<string>? allowedColumns = null
        )
        {
            var (entities, totalCount) = await _userRepository.GetAllAsync(
                page,
                pageSize,
                sortBy,
                sortOrder,
                search,
                filters,
                allowedColumns
            );
            var userDtos = _mapper.Map<List<UserDto>>(entities);

            return new PaginatedResult<UserDto>
            {
                Items = userDtos,
                TotalResults = totalCount,
                Page = page,
                PageSize = pageSize,
            };
        }

        public override async Task<UserDto?> GetByIdAsync(Guid id)
        {
            var entity = await _userRepository.GetByIdAsync(id);
            if (entity == null)
                return null;
            var dto = _mapper.Map<UserDto>(entity);
            return dto;
        }

        public async Task<CsvExportResult> ExportToCsvAsync()
        {
            var allUsers = await _userRepository.FindAsync(_ => true);
            var sb = new StringBuilder();
            sb.AppendLine("Id,DealerName,FullName,Email,Role,LastLoginAt,IsActive");
            foreach (var u in allUsers)
            {
                sb.AppendLine(
                    $"{u.Id},{CsvUtils.EscapeCsv(u.Dealer?.Name ?? "N/A")},{CsvUtils.EscapeCsv(u.FullName)},{CsvUtils.EscapeCsv(u.Email)},{u.Role},{u.LastLoginAt:O},{u.IsActive}"
                );
            }
            var fileName = CsvUtils.BuildCsvFileName("evdms_users", null, null);
            return new CsvExportResult { FileName = fileName, CsvContent = sb.ToString() };
        }

        public async Task<CsvExportResult> ExportByDealerToCsvAsync(Guid dealerId)
        {
            var dealer = await _dealerRepository.GetByIdAsync(dealerId);
            var dealerName = dealer?.Name ?? "N/A";
            var safeDealerName = string.Concat(dealerName.Split(Path.GetInvalidFileNameChars()));
            var users = await _userRepository.FindAsync(u => u.DealerId == dealerId);
            var sb = new StringBuilder();
            sb.AppendLine("Id,FullName,Email,Role,LastLoginAt,IsActive");
            foreach (var u in users)
            {
                sb.AppendLine(
                    $"{u.Id},{CsvUtils.EscapeCsv(u.FullName)},{CsvUtils.EscapeCsv(u.Email)},{u.Role},{u.LastLoginAt:O},{u.IsActive}"
                );
            }
            var fileName =
                $"evdms_users_dealer_{safeDealerName}_{DateTime.UtcNow:yyyyMMddHHmmss}.csv";
            return new CsvExportResult { FileName = fileName, CsvContent = sb.ToString() };
        }
    }
}
