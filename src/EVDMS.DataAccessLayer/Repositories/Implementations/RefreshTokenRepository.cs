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
            return await _dbSet
                .Include(rt => rt.User)
                .FirstOrDefaultAsync(rt => rt.TokenHash == tokenHash);
        }

        public async Task RevokeAsync(string tokenHash)
        {
            var token = await _dbSet.FirstOrDefaultAsync(rt => rt.TokenHash == tokenHash);
            if (token != null)
            {
                token.IsRevoked = true;
                _dbSet.Update(token);
                await _context.SaveChangesAsync();
            }
        }
    }
}
