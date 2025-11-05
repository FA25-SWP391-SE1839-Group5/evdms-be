using System.Linq.Expressions;
using EVDMS.DataAccessLayer.Data;
using EVDMS.DataAccessLayer.Entities;
using EVDMS.DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EVDMS.DataAccessLayer.Repositories.Implementations
{
    public class FeedbackRepository : Repository<Feedback>, IFeedbackRepository
    {
        public FeedbackRepository(AppDbContext context)
            : base(context) { }

        public override async Task<(IEnumerable<Feedback> Items, int TotalCount)> GetAllAsync(
            int page,
            int pageSize,
            string? sortBy = null,
            string? sortOrder = null,
            string? search = null,
            Dictionary<string, string>? filters = null,
            IEnumerable<string>? allowedColumns = null
        )
        {
            var query = _dbSet.Include(f => f.Customer).Include(f => f.Dealer).AsQueryable();

            // Custom search for CustomerFullName, DealerName
            bool searchedCustomerFullName = false,
                searchedDealerName = false;
            if (!string.IsNullOrWhiteSpace(search) && allowedColumns != null)
            {
                var searchLower = search.ToLower();
                searchedCustomerFullName = allowedColumns.Contains("CustomerFullName");
                searchedDealerName = allowedColumns.Contains("DealerName");
                if (searchedCustomerFullName || searchedDealerName)
                {
                    query = query.Where(e =>
                        (
                            searchedCustomerFullName
                            && e.Customer.FullName.ToLower().Contains(searchLower)
                        ) || (searchedDealerName && e.Dealer.Name.ToLower().Contains(searchLower))
                    );
                }
            }

            // Custom sort for CustomerFullName, DealerName
            if (!string.IsNullOrEmpty(sortBy))
            {
                if (string.Equals(sortBy, "CustomerFullName", StringComparison.OrdinalIgnoreCase))
                {
                    query = string.Equals(sortOrder, "desc", StringComparison.OrdinalIgnoreCase)
                        ? query.OrderByDescending(e => e.Customer.FullName)
                        : query.OrderBy(e => e.Customer.FullName);
                }
                else if (string.Equals(sortBy, "DealerName", StringComparison.OrdinalIgnoreCase))
                {
                    query = string.Equals(sortOrder, "desc", StringComparison.OrdinalIgnoreCase)
                        ? query.OrderByDescending(e => e.Dealer.Name)
                        : query.OrderBy(e => e.Dealer.Name);
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

            // Custom filter for CustomerFullName, DealerName (case-insensitive)
            if (filters != null && allowedColumns != null)
            {
                var filtersCI = filters.ToDictionary(
                    kv => kv.Key.ToLowerInvariant(),
                    kv => kv.Value
                );
                if (
                    filtersCI.TryGetValue("customerfullname", out var customerFullNameFilter)
                    && allowedColumns.Any(c =>
                        c.Equals("CustomerFullName", StringComparison.OrdinalIgnoreCase)
                    )
                )
                {
                    var filterLower = customerFullNameFilter.ToLower();
                    query = query.Where(e => e.Customer.FullName.ToLower().Contains(filterLower));
                }
                if (
                    filtersCI.TryGetValue("dealername", out var dealerNameFilter)
                    && allowedColumns.Any(c =>
                        c.Equals("DealerName", StringComparison.OrdinalIgnoreCase)
                    )
                )
                {
                    var filterLower = dealerNameFilter.ToLower();
                    query = query.Where(e => e.Dealer.Name.ToLower().Contains(filterLower));
                }
            }

            // Use base repository's filtering and searching for other columns (excluding custom ones)
            query = ApplyFilters(
                query,
                filters,
                allowedColumns?.Where(c =>
                    !string.Equals(c, "CustomerFullName", StringComparison.OrdinalIgnoreCase)
                    && !string.Equals(c, "DealerName", StringComparison.OrdinalIgnoreCase)
                )
            );
            if (!searchedCustomerFullName && !searchedDealerName)
            {
                query = ApplySearch(
                    query,
                    search,
                    allowedColumns?.Where(c =>
                        !string.Equals(c, "CustomerFullName", StringComparison.OrdinalIgnoreCase)
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
