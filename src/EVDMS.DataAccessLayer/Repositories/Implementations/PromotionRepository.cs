using EVDMS.DataAccessLayer.Data;
using EVDMS.DataAccessLayer.Entities;
using EVDMS.DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EVDMS.DataAccessLayer.Repositories.Implementations
{
    public class PromotionRepository : Repository<Promotion>, IPromotionRepository
    {
        public PromotionRepository(AppDbContext context)
            : base(context) { }

        public override async Task<(IEnumerable<Promotion> Items, int TotalCount)> GetAllAsync(
            int page,
            int pageSize,
            string? sortBy = null,
            string? sortOrder = null,
            string? search = null,
            Dictionary<string, string>? filters = null,
            IEnumerable<string>? allowedColumns = null
        )
        {
            var query = _dbSet.Include(p => p.Dealer).AsQueryable();

            // Custom search for DealerName
            bool searchedDealerName = false;
            if (!string.IsNullOrWhiteSpace(search) && allowedColumns != null)
            {
                var searchLower = search.ToLower();
                searchedDealerName = allowedColumns.Contains("DealerName");
                if (searchedDealerName)
                {
                    // Search DealerName
                    query = query.Where(e =>
                        e.Dealer != null && e.Dealer.Name.ToLower().Contains(searchLower)
                    );
                }
            }

            // Custom sort for DealerName
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
                        e.Dealer != null && e.Dealer.Name.ToLower().Contains(filterLower)
                    );
                }
            }

            // Use base repository's filtering for other columns (excluding DealerName for filter)
            query = ApplyFilters(
                query,
                filters,
                allowedColumns?.Where(c =>
                    !string.Equals(c, "DealerName", StringComparison.OrdinalIgnoreCase)
                )
            );

            // Search both DealerName and other columns if DealerName is allowed
            if (!string.IsNullOrWhiteSpace(search) && allowedColumns != null)
            {
                var otherColumns = allowedColumns.Where(c =>
                    !string.Equals(c, "DealerName", StringComparison.OrdinalIgnoreCase)
                );
                // If DealerName was searched, also search other columns and combine results
                if (searchedDealerName)
                {
                    // Get IDs from DealerName search
                    var dealerNameIds = query.Select(e => e.Id).ToList();
                    // Search other columns
                    var otherQuery = ApplySearch(
                        _dbSet.Include(p => p.Dealer),
                        search,
                        otherColumns
                    );
                    var otherIds = otherQuery.Select(e => e.Id).ToList();
                    // Union results
                    var allIds = dealerNameIds.Union(otherIds).ToList();
                    query = _dbSet.Include(p => p.Dealer).Where(e => allIds.Contains(e.Id));
                }
                else
                {
                    query = ApplySearch(query, search, otherColumns);
                }
            }
            else if (!searchedDealerName)
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
