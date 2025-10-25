using AutoMapper;
using EVDMS.BusinessLogicLayer.Services.Interfaces;
using EVDMS.Common.Dtos;
using EVDMS.Common.Enums;
using EVDMS.DataAccessLayer.Entities;
using EVDMS.DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EVDMS.BusinessLogicLayer.Services.Implementations
{
    public class TestDriveService
        : BaseService<
            TestDrive,
            TestDriveDto,
            CreateTestDriveDto,
            UpdateTestDriveDto,
            PatchTestDriveDto
        >,
            ITestDriveService
    {
        private readonly ITestDriveRepository _testDriveRepository;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly ICustomerRepository _customerRepository;

        public TestDriveService(
            ITestDriveRepository testDriveRepository,
            IVehicleRepository vehicleRepository,
            ICustomerRepository customerRepository,
            IMapper mapper
        )
            : base(testDriveRepository, mapper)
        {
            _testDriveRepository = testDriveRepository;
            _vehicleRepository = vehicleRepository;
            _customerRepository = customerRepository;
        }

        public async Task<TestDriveDto> CreateAsync(CreateTestDriveDto dto, Guid dealerId)
        {
            _ =
                await _customerRepository.GetByIdAsync(dto.CustomerId)
                ?? throw new KeyNotFoundException("Customer not found.");

            // Check vehicle exists, is available, and is Demo
            var vehicle =
                await _vehicleRepository.GetByIdAsync(dto.VehicleId)
                ?? throw new KeyNotFoundException("Vehicle not found.");
            if (vehicle.Status != VehicleStatus.Available)
                throw new InvalidOperationException("Vehicle must be available.");
            if (vehicle.Type != VehicleType.Demo)
                throw new InvalidOperationException("Vehicle must be of type Demo.");

            // Check for customer test drive time conflict
            var overlapping = await _testDriveRepository.FindAsync(td =>
                td.CustomerId == dto.CustomerId && td.ScheduledAt == dto.ScheduledAt
            );
            if (overlapping.Any())
                throw new InvalidOperationException(
                    "Customer already has a test drive scheduled at this time."
                );

            var entity = _mapper.Map<TestDrive>(dto);
            entity.DealerId = dealerId;
            entity.Status = TestDriveStatus.Scheduled;

            vehicle.Status = VehicleStatus.Reserved;
            _vehicleRepository.Update(vehicle);

            await _testDriveRepository.AddAsync(entity);
            await _testDriveRepository.SaveChangesAsync();
            await _vehicleRepository.SaveChangesAsync();
            return _mapper.Map<TestDriveDto>(entity);
        }

        public override async Task<bool> PatchAsync(Guid id, PatchTestDriveDto dto)
        {
            var entity = await _testDriveRepository.GetByIdAsync(id);
            if (entity == null)
                return false;
            _ = entity.Status;
            _mapper.Map(dto, entity);
            _testDriveRepository.Update(entity);
            await _testDriveRepository.SaveChangesAsync();

            if (
                dto.Status.HasValue
                && (
                    dto.Status == TestDriveStatus.Completed
                    || dto.Status == TestDriveStatus.Canceled
                    || dto.Status == TestDriveStatus.NoShow
                )
            )
            {
                var vehicle = await _vehicleRepository.GetByIdAsync(entity.VehicleId);
                if (vehicle != null)
                {
                    vehicle.Status = VehicleStatus.Available;
                    _vehicleRepository.Update(vehicle);
                    await _vehicleRepository.SaveChangesAsync();
                }
            }
            return true;
        }
    }
}
