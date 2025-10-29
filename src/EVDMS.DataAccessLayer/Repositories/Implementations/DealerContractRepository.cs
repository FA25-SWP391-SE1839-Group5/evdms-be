using System.Linq.Expressions;
using EVDMS.DataAccessLayer.Data;
using EVDMS.DataAccessLayer.Entities;
using EVDMS.DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EVDMS.DataAccessLayer.Repositories.Implementations
{
    public class DealerContractRepository : Repository<DealerContract>, IDealerContractRepository
    {
        public DealerContractRepository(AppDbContext context)
            : base(context) { }

        public override async Task<(IEnumerable<DealerContract> Items, int TotalCount)> GetAllAsync(
            int page,
            int pageSize,
            string? sortBy = null,
            string? sortOrder = null,
            string? search = null,
            Dictionary<string, string>? filters = null,
            IEnumerable<string>? allowedColumns = null
        )
        {
            var query = _dbSet.Include(dc => dc.Dealer).AsQueryable();

            // Always search DealerName if search is provided
            if (!string.IsNullOrWhiteSpace(search))
            {
                var parameter = Expression.Parameter(typeof(DealerContract), "e");
                var dealerAccess = Expression.Property(parameter, nameof(DealerContract.Dealer));
                var nameProperty = typeof(Dealer).GetProperty("Name");
                if (nameProperty != null)
                {
                    var nameAccess = Expression.Property(dealerAccess, nameProperty);
                    var toLowerMethod = typeof(string).GetMethod("ToLower", Type.EmptyTypes);
                    var nameToLower = Expression.Call(nameAccess, toLowerMethod!);
                    var searchValue = Expression.Constant(search.ToLower());
                    var containsMethod = typeof(string).GetMethod(
                        "Contains",
                        new[] { typeof(string) }
                    );
                    var contains = Expression.Call(nameToLower, containsMethod!, searchValue);
                    var lambda = Expression.Lambda<Func<DealerContract, bool>>(contains, parameter);
                    query = query.Where(lambda);
                }
            }

            // Custom sort for DealerName
            if (
                !string.IsNullOrEmpty(sortBy)
                && string.Equals(sortBy, "DealerName", StringComparison.OrdinalIgnoreCase)
            )
            {
                if (string.Equals(sortOrder, "desc", StringComparison.OrdinalIgnoreCase))
                    query = query.OrderByDescending(e => e.Dealer.Name);
                else
                    query = query.OrderBy(e => e.Dealer.Name);
            }
            else
            {
                // Use base repository's filtering, searching, and sorting logic
                query = ApplyFilters(query, filters, allowedColumns);
                query = ApplySearch(query, search, allowedColumns);
                query = ApplySorting(query, sortBy, sortOrder);
            }

            var totalCount = await query.CountAsync();
            var items = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            return (items, totalCount);
        }
    }
}
