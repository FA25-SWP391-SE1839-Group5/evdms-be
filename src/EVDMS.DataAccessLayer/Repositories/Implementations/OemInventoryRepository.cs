using System.Linq.Expressions;
using EVDMS.DataAccessLayer.Data;
using EVDMS.DataAccessLayer.Entities;
using EVDMS.DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EVDMS.DataAccessLayer.Repositories.Implementations
{
    public class OemInventoryRepository : Repository<OemInventory>, IOemInventoryRepository
    {
        public OemInventoryRepository(AppDbContext context)
            : base(context) { }

        public override async Task<OemInventory?> GetByIdAsync(Guid id)
        {
            return await _dbSet.Include(x => x.VehicleVariant).FirstOrDefaultAsync(x => x.Id == id);
        }

        public override async Task<(IEnumerable<OemInventory> Items, int TotalCount)> GetAllAsync(
            int page,
            int pageSize,
            string? sortBy = null,
            string? sortOrder = null,
            string? search = null,
            Dictionary<string, string>? filters = null,
            IEnumerable<string>? allowedColumns = null
        )
        {
            // Start with include for VehicleVariant
            var query = _dbSet.Include(x => x.VehicleVariant).AsQueryable();

            // Custom search for VariantName (VehicleVariant.Name)
            if (
                !string.IsNullOrWhiteSpace(search)
                && allowedColumns != null
                && allowedColumns.Contains("VariantName")
            )
            {
                var parameter = Expression.Parameter(typeof(OemInventory), "e");
                var vehicleVariantAccess = Expression.Property(
                    parameter,
                    nameof(OemInventory.VehicleVariant)
                );
                var nameProperty = typeof(VehicleVariant).GetProperty("Name");
                if (nameProperty != null)
                {
                    var nameAccess = Expression.Property(vehicleVariantAccess, nameProperty);
                    var toLowerMethod = typeof(string).GetMethod("ToLower", Type.EmptyTypes);
                    var nameToLower = Expression.Call(nameAccess, toLowerMethod!);
                    var searchValue = Expression.Constant(search.ToLower());
                    var containsMethod = typeof(string).GetMethod(
                        "Contains",
                        new[] { typeof(string) }
                    );
                    var contains = Expression.Call(nameToLower, containsMethod!, searchValue);
                    var lambda = Expression.Lambda<Func<OemInventory, bool>>(contains, parameter);
                    query = query.Where(lambda);
                }
            }

            // Custom sort for VariantName
            if (
                !string.IsNullOrEmpty(sortBy)
                && string.Equals(sortBy, "VariantName", StringComparison.OrdinalIgnoreCase)
            )
            {
                if (string.Equals(sortOrder, "desc", StringComparison.OrdinalIgnoreCase))
                    query = query.OrderByDescending(e => e.VehicleVariant.Name);
                else
                    query = query.OrderBy(e => e.VehicleVariant.Name);
            }
            else
            {
                // Use base repository's filtering, searching, and sorting logic
                query = ApplyFilters(query, filters, allowedColumns);
                query = ApplySearch(
                    query,
                    search,
                    allowedColumns?.Where(c =>
                        !string.Equals(c, "VariantName", StringComparison.OrdinalIgnoreCase)
                    )
                );
                query = ApplySorting(query, sortBy, sortOrder);
            }

            var totalCount = await query.CountAsync();
            var items = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            return (items, totalCount);
        }
    }
}
