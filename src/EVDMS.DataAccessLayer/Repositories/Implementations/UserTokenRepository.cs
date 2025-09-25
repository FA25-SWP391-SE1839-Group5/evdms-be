using EVDMS.DataAccessLayer.Data;
using EVDMS.DataAccessLayer.Entities;
using EVDMS.DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EVDMS.DataAccessLayer.Repositories.Implementations
{
    public class UserTokenRepository : Repository<UserToken>, IUserTokenRepository
    {
        public UserTokenRepository(AppDbContext context)
            : base(context) { }

        public async Task<UserToken?> GetByTokenHashAsync(string tokenHash)
        {
            return await _context.UserTokens.FirstOrDefaultAsync(t => t.TokenHash == tokenHash);
        }
    }
}
