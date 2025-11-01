using System.Linq.Expressions;
using EVDMS.DataAccessLayer.Data;
using EVDMS.DataAccessLayer.Entities;
using EVDMS.DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EVDMS.DataAccessLayer.Repositories.Implementations
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context)
            : base(context) { }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context
                .Users.Include(u => u.Dealer)
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<bool> ExistsByEmailAsync(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email);
        }

        public override async Task<User?> GetByIdAsync(Guid id)
        {
            return await _context.Users.Include(u => u.Dealer).FirstOrDefaultAsync(u => u.Id == id);
        }

        public override async Task<(IEnumerable<User> Items, int TotalCount)> GetAllAsync(
            int page,
            int pageSize,
            string? sortBy = null,
            string? sortOrder = null,
            string? search = null,
            Dictionary<string, string>? filters = null,
            IEnumerable<string>? allowedColumns = null
        )
        {
            var query = _context.Users.Include(u => u.Dealer).AsQueryable();

            // Custom search for DealerName only
            bool searchedDealerName = false;
            if (!string.IsNullOrWhiteSpace(search) && allowedColumns != null)
            {
                var searchLower = search.ToLower();
                searchedDealerName = allowedColumns.Contains("DealerName");
                if (searchedDealerName)
                {
                    query = query.Where(e =>
                        e.Dealer != null
                        && e.Dealer.Name.Contains(
                            searchLower,
                            StringComparison.CurrentCultureIgnoreCase
                        )
                    );
                }
            }

            // Custom sort for DealerName only
            if (!string.IsNullOrEmpty(sortBy))
            {
                if (string.Equals(sortBy, "DealerName", StringComparison.OrdinalIgnoreCase))
                {
                    query = string.Equals(sortOrder, "desc", StringComparison.OrdinalIgnoreCase)
                        ? query.OrderByDescending(e => e.Dealer != null ? e.Dealer.Name : null)
                        : query.OrderBy(e => e.Dealer != null ? e.Dealer.Name : null);
                }
                else
                {
                    query = ApplySorting(query, sortBy, sortOrder);
                }
            }
            else
            {
                query = ApplySorting(query, sortBy, sortOrder);
            }

            // Custom filter for DealerName (case-insensitive)
            if (filters != null && allowedColumns != null)
            {
                var filtersCI = filters.ToDictionary(
                    kv => kv.Key.ToLowerInvariant(),
                    kv => kv.Value
                );
                if (
                    filtersCI.TryGetValue("dealername", out var dealerNameFilter)
                    && allowedColumns.Any(c =>
                        c.Equals("DealerName", StringComparison.OrdinalIgnoreCase)
                    )
                )
                {
                    var filterLower = dealerNameFilter.ToLower();
                    query = query.Where(e =>
                        e.Dealer != null
                        && e.Dealer.Name.Contains(
                            filterLower,
                            StringComparison.CurrentCultureIgnoreCase
                        )
                    );
                }
            }

            // Use base repository's filtering and searching for other columns (excluding DealerName for search)
            query = ApplyFilters(
                query,
                filters,
                allowedColumns?.Where(c =>
                    !string.Equals(c, "DealerName", StringComparison.OrdinalIgnoreCase)
                )
            );
            if (!searchedDealerName)
            {
                query = ApplySearch(
                    query,
                    search,
                    allowedColumns?.Where(c =>
                        !string.Equals(c, "DealerName", StringComparison.OrdinalIgnoreCase)
                    )
                );
            }

            var totalCount = await query.CountAsync();
            var items = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            return (items, totalCount);
        }
    }
}
