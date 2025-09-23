using System.Threading.Tasks;
using EVDMS.DataAccessLayer.Data;
using EVDMS.DataAccessLayer.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace EVDMS.DataAccessLayer.Tests.Unit.UnitOfWork
{
    public class UnitOfWorkTests
    {
        [Trait("Category", "Unit")]
        [Fact]
        public async Task CompleteAsync_CallsSaveChangesAsyncOnContext()
        {
            var mockContext = new Mock<AppDbContext>(new DbContextOptions<AppDbContext>());
            mockContext.Setup(m => m.SaveChangesAsync(default)).ReturnsAsync(1);
            var unitOfWork = new DataAccessLayer.UnitOfWork.UnitOfWork(mockContext.Object);

            var result = await unitOfWork.CompleteAsync();

            mockContext.Verify(m => m.SaveChangesAsync(default), Times.Once);
            Assert.Equal(1, result);
        }

        [Trait("Category", "Unit")]
        [Fact]
        public void Dispose_CallsDisposeOnContext()
        {
            var mockContext = new Mock<AppDbContext>(new DbContextOptions<AppDbContext>());
            var unitOfWork = new DataAccessLayer.UnitOfWork.UnitOfWork(mockContext.Object);

            unitOfWork.Dispose();

            mockContext.Verify(m => m.Dispose(), Times.Once);
        }
    }
}
