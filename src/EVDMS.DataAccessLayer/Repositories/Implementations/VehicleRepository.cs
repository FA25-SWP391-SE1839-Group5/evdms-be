using System.Linq.Expressions;
using EVDMS.DataAccessLayer.Data;
using EVDMS.DataAccessLayer.Entities;
using EVDMS.DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EVDMS.DataAccessLayer.Repositories.Implementations
{
    public class VehicleRepository : Repository<Vehicle>, IVehicleRepository
    {
        public VehicleRepository(AppDbContext context)
            : base(context) { }

        public override async Task<(IEnumerable<Vehicle> Items, int TotalCount)> GetAllAsync(
            int page,
            int pageSize,
            string? sortBy = null,
            string? sortOrder = null,
            string? search = null,
            Dictionary<string, string>? filters = null,
            IEnumerable<string>? allowedColumns = null
        )
        {
            var query = _dbSet.Include(v => v.VehicleVariant).AsQueryable();

            // Custom search for VariantName
            bool searchedVariantName = false;
            if (!string.IsNullOrWhiteSpace(search) && allowedColumns != null)
            {
                var searchLower = search.ToLower();
                searchedVariantName = allowedColumns.Contains("VariantName");
                if (searchedVariantName)
                {
                    query = query.Where(e => e.VehicleVariant.Name.ToLower().Contains(searchLower));
                }
            }

            // Custom sort for VariantName
            if (!string.IsNullOrEmpty(sortBy))
            {
                if (string.Equals(sortBy, "VariantName", StringComparison.OrdinalIgnoreCase))
                {
                    query = string.Equals(sortOrder, "desc", StringComparison.OrdinalIgnoreCase)
                        ? query.OrderByDescending(e => e.VehicleVariant.Name)
                        : query.OrderBy(e => e.VehicleVariant.Name);
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

            // Custom filter for VariantName (case-insensitive)
            if (filters != null && allowedColumns != null)
            {
                var filtersCI = filters.ToDictionary(
                    kv => kv.Key.ToLowerInvariant(),
                    kv => kv.Value
                );
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

            // Use base repository's filtering and searching for other columns (excluding custom ones)
            query = ApplyFilters(
                query,
                filters,
                allowedColumns?.Where(c =>
                    !string.Equals(c, "VariantName", StringComparison.OrdinalIgnoreCase)
                )
            );
            if (!searchedVariantName)
            {
                query = ApplySearch(
                    query,
                    search,
                    allowedColumns?.Where(c =>
                        !string.Equals(c, "VariantName", StringComparison.OrdinalIgnoreCase)
                    )
                );
            }

            var totalCount = await query.CountAsync();
            var items = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            return (items, totalCount);
        }

        public override async Task<Vehicle?> GetByIdAsync(Guid id)
        {
            return await _dbSet.Include(v => v.VehicleVariant).FirstOrDefaultAsync(v => v.Id == id);
        }
    }
}
