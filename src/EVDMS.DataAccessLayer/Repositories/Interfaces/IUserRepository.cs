using EVDMS.DataAccessLayer.Entities;

namespace EVDMS.DataAccessLayer.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User?> GetByEmailAsync(string email);
        Task<bool> ExistsByEmailAsync(string email);
        // Add more custom methods as needed
    }
}
