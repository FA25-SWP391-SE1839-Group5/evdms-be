using EVDMS.DataAccessLayer.Data;
using EVDMS.DataAccessLayer.Entities;
using EVDMS.DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EVDMS.DataAccessLayer.Repositories.Implementations
{
    public class RefreshTokenRepository : Repository<RefreshToken>, IRefreshTokenRepository
    {
        public RefreshTokenRepository(AppDbContext context)
            : base(context) { }

        public async Task<RefreshToken?> GetByTokenHashAsync(string tokenHash)
        {
            return await _context
                .RefreshTokens.Include(r => r.User)
                .FirstOrDefaultAsync(r => r.TokenHash == tokenHash);
        }

        public async Task<IEnumerable<RefreshToken>> GetByUserIdAsync(Guid userId)
        {
            return await _context.RefreshTokens.Where(r => r.UserId == userId).ToListAsync();
        }
    }
}
