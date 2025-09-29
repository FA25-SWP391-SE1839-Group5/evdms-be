using EVDMS.DataAccessLayer.Data;
using EVDMS.DataAccessLayer.Entities;
using EVDMS.DataAccessLayer.Repositories.Interfaces;

namespace EVDMS.DataAccessLayer.Repositories.Implementations
{
    public class TestDriveRepository : Repository<TestDrive>, ITestDriveRepository
    {
        public TestDriveRepository(AppDbContext context)
            : base(context) { }
    }
}
