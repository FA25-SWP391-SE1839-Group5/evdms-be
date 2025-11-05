using System.Linq.Expressions;
using EVDMS.DataAccessLayer.Data;
using EVDMS.DataAccessLayer.Entities;
using EVDMS.DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EVDMS.DataAccessLayer.Repositories.Implementations
{
    public class DealerOrderRepository : Repository<DealerOrder>, IDealerOrderRepository
    {
        public DealerOrderRepository(AppDbContext context)
            : base(context) { }

        public override async Task<(IEnumerable<DealerOrder> Items, int TotalCount)> GetAllAsync(
            int page,
            int pageSize,
            string? sortBy = null,
            string? sortOrder = null,
            string? search = null,
            Dictionary<string, string>? filters = null,
            IEnumerable<string>? allowedColumns = null
        )
        {
            var query = _dbSet.Include(x => x.Dealer).Include(x => x.VehicleVariant).AsQueryable();

            // Custom search for DealerName and VariantName
            if (!string.IsNullOrWhiteSpace(search) && allowedColumns != null)
            {
                var searchLower = search.ToLower();
                bool dealerName = allowedColumns.Contains("DealerName");
                bool variantName = allowedColumns.Contains("VariantName");
                if (dealerName || variantName)
                {
                    query = query.Where(e =>
                        (dealerName && e.Dealer.Name.ToLower().Contains(searchLower))
                        || (variantName && e.VehicleVariant.Name.ToLower().Contains(searchLower))
                    );
                }
            }

            // Custom sort for DealerName and VariantName
            if (!string.IsNullOrEmpty(sortBy))
            {
                if (string.Equals(sortBy, "DealerName", StringComparison.OrdinalIgnoreCase))
                {
                    query = string.Equals(sortOrder, "desc", StringComparison.OrdinalIgnoreCase)
                        ? query.OrderByDescending(e => e.Dealer.Name)
                        : query.OrderBy(e => e.Dealer.Name);
                }
                else if (string.Equals(sortBy, "VariantName", StringComparison.OrdinalIgnoreCase))
                {
                    query = string.Equals(sortOrder, "desc", StringComparison.OrdinalIgnoreCase)
                        ? query.OrderByDescending(e => e.VehicleVariant.Name)
                        : query.OrderBy(e => e.VehicleVariant.Name);
                }
                else
                {
                    // Use base repository's sorting for other columns
                    query = ApplySorting(query, sortBy, sortOrder);
                }
            }
            else
            {
                query = ApplySorting(query, sortBy, sortOrder);
            }

            // Custom filter for DealerName and VariantName (case-insensitive key)
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
                    query = query.Where(e => e.Dealer.Name.ToLower().Contains(filterLower));
                }
                if (
                    filtersCI.TryGetValue("variantname", out var variantNameFilter)
                    && allowedColumns.Any(c =>
                        c.Equals("VariantName", StringComparison.OrdinalIgnoreCase)
                    )
                )
                {
                    var filterLower = variantNameFilter.ToLower();
                    query = query.Where(e => e.VehicleVariant.Name.ToLower().Contains(filterLower));
                }
            }

            // Use base repository's filtering and searching for other columns
            query = ApplyFilters(
                query,
                filters,
                allowedColumns?.Where(c => c != "DealerName" && c != "VariantName")
            );
            query = ApplySearch(
                query,
                search,
                allowedColumns?.Where(c => c != "DealerName" && c != "VariantName")
            );

            var totalCount = await query.CountAsync();
            var items = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            return (items, totalCount);
        }
    }
}
