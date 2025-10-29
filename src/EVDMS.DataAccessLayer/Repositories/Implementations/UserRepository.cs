using System.Linq.Expressions;
using EVDMS.DataAccessLayer.Data;
using EVDMS.DataAccessLayer.Entities;
using EVDMS.DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EVDMS.DataAccessLayer.Repositories.Implementations
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context)
            : base(context) { }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context
                .Users.Include(u => u.Dealer)
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<bool> ExistsByEmailAsync(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email);
        }

        public override async Task<User?> GetByIdAsync(Guid id)
        {
            return await _context.Users.Include(u => u.Dealer).FirstOrDefaultAsync(u => u.Id == id);
        }

        public override async Task<(IEnumerable<User> Items, int TotalCount)> GetAllAsync(
            int page,
            int pageSize,
            string? sortBy = null,
            string? sortOrder = null,
            string? search = null,
            Dictionary<string, string>? filters = null,
            IEnumerable<string>? allowedColumns = null
        )
        {
            var query = _context.Users.Include(u => u.Dealer).AsQueryable();
            query = ApplyFilters(query, filters, allowedColumns);
            query = ApplySearch(query, search, allowedColumns);
            query = ApplySorting(query, sortBy, sortOrder);

            var totalCount = await query.CountAsync();
            var items = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            return (items, totalCount);
        }
    }
}
