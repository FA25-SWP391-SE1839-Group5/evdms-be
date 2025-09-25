using System.Threading.Tasks;
using EVDMS.DataAccessLayer.Entities;

namespace EVDMS.DataAccessLayer.Repositories.Interfaces
{
    public interface IUserTokenRepository : IRepository<UserToken>
    {
        Task<UserToken?> GetByTokenHashAsync(string tokenHash);
    }
}
