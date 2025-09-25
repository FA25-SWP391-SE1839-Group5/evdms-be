using EVDMS.DataAccessLayer.Entities;

namespace EVDMS.DataAccessLayer.Repositories.Interfaces
{
    public interface IRefreshTokenRepository : IRepository<RefreshToken>
    {
        Task<RefreshToken?> GetByTokenHashAsync(string tokenHash);
        Task<IEnumerable<RefreshToken>> GetByUserIdAsync(Guid userId);
    }
}
