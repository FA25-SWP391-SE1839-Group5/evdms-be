using System.Text;
using AutoMapper;
using EVDMS.BusinessLogicLayer.Services.Interfaces;
using EVDMS.Common.Dtos;
using EVDMS.Common.Utils;
using EVDMS.DataAccessLayer.Entities;
using EVDMS.DataAccessLayer.Repositories.Interfaces;

namespace EVDMS.BusinessLogicLayer.Services.Implementations
{
    public class CustomerService
        : BaseService<
            Customer,
            CustomerDto,
            CreateCustomerDto,
            UpdateCustomerDto,
            PatchCustomerDto
        >,
            ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
            : base(customerRepository, mapper)
        {
            _customerRepository = customerRepository;
        }

        public async Task<CsvExportResult> ExportToCsvAsync()
        {
            var allCustomers = await _customerRepository.FindAsync(_ => true);
            var dtos = _mapper.Map<IEnumerable<CustomerDto>>(allCustomers);
            var sb = new StringBuilder();
            sb.AppendLine("Id,FullName,Phone,Email,Address,CreatedAt,UpdatedAt");
            foreach (var c in dtos)
            {
                sb.AppendLine(
                    $"{c.Id},{CsvUtils.EscapeCsv(c.FullName)},{CsvUtils.EscapeCsv(c.Phone)},{CsvUtils.EscapeCsv(c.Email)},{CsvUtils.EscapeCsv(c.Address)},{c.CreatedAt:O},{c.UpdatedAt:O}"
                );
            }
            var fileName = CsvUtils.BuildCsvFileName("evdms_customers", null, null);
            return new CsvExportResult { FileName = fileName, CsvContent = sb.ToString() };
        }
    }
}
