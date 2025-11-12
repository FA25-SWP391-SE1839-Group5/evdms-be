using EVDMS.DataAccessLayer.Data;
using EVDMS.DataAccessLayer.Entities;
using EVDMS.DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EVDMS.DataAccessLayer.Repositories.Implementations
{
    public class DealerPaymentRepository : Repository<DealerPayment>, IDealerPaymentRepository
    {
        public DealerPaymentRepository(AppDbContext context)
            : base(context) { }

        public override async Task<(IEnumerable<DealerPayment> Items, int TotalCount)> GetAllAsync(
            int page,
            int pageSize,
            string? sortBy = null,
            string? sortOrder = null,
            string? search = null,
            Dictionary<string, string>? filters = null,
            IEnumerable<string>? allowedColumns = null
        )
        {
            var query = _dbSet.Include(dp => dp.DealerOrder.Dealer).AsQueryable();

            // Custom search for DealerId and DealerName
            bool searchedDealerId = false,
                searchedDealerName = false;
            if (!string.IsNullOrWhiteSpace(search) && allowedColumns != null)
            {
                var searchLower = search.ToLower();
                searchedDealerId = allowedColumns.Contains("DealerId");
                searchedDealerName = allowedColumns.Contains("DealerName");
                if (searchedDealerId || searchedDealerName)
                {
                    query = query.Where(e =>
                        (
                            searchedDealerId
                            && e.DealerOrder.DealerId.ToString().ToLower().Contains(searchLower)
                        )
                        || (
                            searchedDealerName
                            && e.DealerOrder.Dealer.Name.ToLower().Contains(searchLower)
                        )
                    );
                }
            }

            // Custom sort for DealerId and DealerName
            if (!string.IsNullOrEmpty(sortBy))
            {
                if (string.Equals(sortBy, "DealerId", StringComparison.OrdinalIgnoreCase))
                {
                    query = string.Equals(sortOrder, "desc", StringComparison.OrdinalIgnoreCase)
                        ? query.OrderByDescending(e => e.DealerOrder.DealerId)
                        : query.OrderBy(e => e.DealerOrder.DealerId);
                }
                else if (string.Equals(sortBy, "DealerName", StringComparison.OrdinalIgnoreCase))
                {
                    query = string.Equals(sortOrder, "desc", StringComparison.OrdinalIgnoreCase)
                        ? query.OrderByDescending(e => e.DealerOrder.Dealer.Name)
                        : query.OrderBy(e => e.DealerOrder.Dealer.Name);
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

            // Custom filter for DealerId and DealerName (case-insensitive)
            if (filters != null && allowedColumns != null)
            {
                var filtersCI = filters.ToDictionary(
                    kv => kv.Key.ToLowerInvariant(),
                    kv => kv.Value
                );
                if (
                    filtersCI.TryGetValue("dealerid", out var dealerIdFilter)
                    && allowedColumns.Any(c =>
                        c.Equals("DealerId", StringComparison.OrdinalIgnoreCase)
                    )
                )
                {
                    var filterLower = dealerIdFilter.ToLower();
                    query = query.Where(e =>
                        e.DealerOrder.DealerId.ToString().ToLower().Contains(filterLower)
                    );
                }
                if (
                    filtersCI.TryGetValue("dealername", out var dealerNameFilter)
                    && allowedColumns.Any(c =>
                        c.Equals("DealerName", StringComparison.OrdinalIgnoreCase)
                    )
                )
                {
                    var filterLower = dealerNameFilter.ToLower();
                    query = query.Where(e =>
                        e.DealerOrder.Dealer.Name.ToLower().Contains(filterLower)
                    );
                }
            }

            // Use base repository's filtering and searching for other columns (excluding DealerId/DealerName for search)
            query = ApplyFilters(
                query,
                filters,
                allowedColumns?.Where(c =>
                    !string.Equals(c, "DealerId", StringComparison.OrdinalIgnoreCase)
                    && !string.Equals(c, "DealerName", StringComparison.OrdinalIgnoreCase)
                )
            );
            if (!searchedDealerId && !searchedDealerName)
            {
                query = ApplySearch(
                    query,
                    search,
                    allowedColumns?.Where(c =>
                        !string.Equals(c, "DealerId", StringComparison.OrdinalIgnoreCase)
                        && !string.Equals(c, "DealerName", StringComparison.OrdinalIgnoreCase)
                    )
                );
            }

            var totalCount = await query.CountAsync();
            var items = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            return (items, totalCount);
        }
    }
}
