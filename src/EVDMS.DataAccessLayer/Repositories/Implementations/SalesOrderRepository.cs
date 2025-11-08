using System.Linq.Expressions;
using EVDMS.Common.Utils;
using EVDMS.DataAccessLayer.Data;
using EVDMS.DataAccessLayer.Entities;
using EVDMS.DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EVDMS.DataAccessLayer.Repositories.Implementations
{
    public class SalesOrderRepository : Repository<SalesOrder>, ISalesOrderRepository
    {
        public SalesOrderRepository(AppDbContext context)
            : base(context) { }

        // Get sales orders with related details
        public async Task<List<SalesOrder>> GetSalesOrdersWithDetailsAsync()
        {
            return await _context
                .SalesOrders.Include(so => so.Dealer)
                .Include(so => so.User)
                .Include(so => so.Customer)
                .Include(so => so.Vehicle)
                .ToListAsync();
        }

        public override async Task<(IEnumerable<SalesOrder> Items, int TotalCount)> GetAllAsync(
            int page,
            int pageSize,
            string? sortBy = null,
            string? sortOrder = null,
            string? search = null,
            Dictionary<string, string>? filters = null,
            IEnumerable<string>? allowedColumns = null
        )
        {
            var query = _dbSet
                .Include(so => so.Dealer)
                .Include(so => so.User)
                .Include(so => so.Customer)
                .Include(so => so.Vehicle)
                .AsQueryable();

            // Custom sort for DealerName, UserFullName, CustomerFullName, VehicleVin
            if (!string.IsNullOrEmpty(sortBy))
            {
                if (string.Equals(sortBy, "DealerName", StringComparison.OrdinalIgnoreCase))
                {
                    query = string.Equals(sortOrder, "desc", StringComparison.OrdinalIgnoreCase)
                        ? query.OrderByDescending(e => e.Dealer.Name)
                        : query.OrderBy(e => e.Dealer.Name);
                }
                else if (string.Equals(sortBy, "UserFullName", StringComparison.OrdinalIgnoreCase))
                {
                    query = string.Equals(sortOrder, "desc", StringComparison.OrdinalIgnoreCase)
                        ? query.OrderByDescending(e => e.User.FullName)
                        : query.OrderBy(e => e.User.FullName);
                }
                else if (
                    string.Equals(sortBy, "CustomerFullName", StringComparison.OrdinalIgnoreCase)
                )
                {
                    query = string.Equals(sortOrder, "desc", StringComparison.OrdinalIgnoreCase)
                        ? query.OrderByDescending(e => e.Customer.FullName)
                        : query.OrderBy(e => e.Customer.FullName);
                }
                else if (string.Equals(sortBy, "VehicleVin", StringComparison.OrdinalIgnoreCase))
                {
                    query = string.Equals(sortOrder, "desc", StringComparison.OrdinalIgnoreCase)
                        ? query.OrderByDescending(e => e.Vehicle.Vin)
                        : query.OrderBy(e => e.Vehicle.Vin);
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

            // Use base repository's filtering and searching for other columns (excluding custom ones)
            query = ApplyFilters(
                query,
                filters,
                allowedColumns?.Where(c =>
                    !string.Equals(c, "DealerName", StringComparison.OrdinalIgnoreCase)
                    && !string.Equals(c, "UserFullName", StringComparison.OrdinalIgnoreCase)
                    && !string.Equals(c, "CustomerFullName", StringComparison.OrdinalIgnoreCase)
                    && !string.Equals(c, "VehicleVin", StringComparison.OrdinalIgnoreCase)
                )
            );
            if (
                string.IsNullOrWhiteSpace(search)
                || allowedColumns == null
                || (
                    !allowedColumns.Contains("DealerName")
                    && !allowedColumns.Contains("UserFullName")
                    && !allowedColumns.Contains("CustomerFullName")
                    && !allowedColumns.Contains("VehicleVin")
                )
            )
            {
                query = ApplySearch(
                    query,
                    search,
                    allowedColumns?.Where(c =>
                        !string.Equals(c, "DealerName", StringComparison.OrdinalIgnoreCase)
                        && !string.Equals(c, "UserFullName", StringComparison.OrdinalIgnoreCase)
                        && !string.Equals(c, "CustomerFullName", StringComparison.OrdinalIgnoreCase)
                        && !string.Equals(c, "VehicleVin", StringComparison.OrdinalIgnoreCase)
                    )
                );
            }

            // Materialize the query ONCE
            var queryList = await query.ToListAsync();

            // In-memory diacritic-insensitive search for DealerName, UserFullName, CustomerFullName, VehicleVin
            if (
                !string.IsNullOrWhiteSpace(search)
                && allowedColumns != null
                && (
                    allowedColumns.Contains("DealerName")
                    || allowedColumns.Contains("UserFullName")
                    || allowedColumns.Contains("CustomerFullName")
                    || allowedColumns.Contains("VehicleVin")
                )
            )
            {
                var searchNoDiacritics = DiacriticUtils.RemoveDiacritics(search.ToLower());
                queryList = queryList
                    .Where(e =>
                        (
                            allowedColumns.Contains("DealerName")
                            && DiacriticUtils
                                .RemoveDiacritics(e.Dealer.Name.ToLower())
                                .Contains(searchNoDiacritics)
                        )
                        || (
                            allowedColumns.Contains("UserFullName")
                            && DiacriticUtils
                                .RemoveDiacritics(e.User.FullName.ToLower())
                                .Contains(searchNoDiacritics)
                        )
                        || (
                            allowedColumns.Contains("CustomerFullName")
                            && DiacriticUtils
                                .RemoveDiacritics(e.Customer.FullName.ToLower())
                                .Contains(searchNoDiacritics)
                        )
                        || (
                            allowedColumns.Contains("VehicleVin")
                            && DiacriticUtils
                                .RemoveDiacritics(e.Vehicle.Vin.ToLower())
                                .Contains(searchNoDiacritics)
                        )
                    )
                    .ToList();
            }

            // In-memory diacritic-insensitive filter for DealerName, UserFullName, CustomerFullName, VehicleVin
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
                    var filterNoDiacritics = DiacriticUtils.RemoveDiacritics(
                        dealerNameFilter.ToLower()
                    );
                    queryList = queryList
                        .Where(e =>
                            DiacriticUtils
                                .RemoveDiacritics(e.Dealer.Name.ToLower())
                                .Contains(filterNoDiacritics)
                        )
                        .ToList();
                }
                if (
                    filtersCI.TryGetValue("userfullname", out var userFullNameFilter)
                    && allowedColumns.Any(c =>
                        c.Equals("UserFullName", StringComparison.OrdinalIgnoreCase)
                    )
                )
                {
                    var filterNoDiacritics = DiacriticUtils.RemoveDiacritics(
                        userFullNameFilter.ToLower()
                    );
                    queryList = queryList
                        .Where(e =>
                            DiacriticUtils
                                .RemoveDiacritics(e.User.FullName.ToLower())
                                .Contains(filterNoDiacritics)
                        )
                        .ToList();
                }
                if (
                    filtersCI.TryGetValue("customerfullname", out var customerFullNameFilter)
                    && allowedColumns.Any(c =>
                        c.Equals("CustomerFullName", StringComparison.OrdinalIgnoreCase)
                    )
                )
                {
                    var filterNoDiacritics = DiacriticUtils.RemoveDiacritics(
                        customerFullNameFilter.ToLower()
                    );
                    queryList = queryList
                        .Where(e =>
                            DiacriticUtils
                                .RemoveDiacritics(e.Customer.FullName.ToLower())
                                .Contains(filterNoDiacritics)
                        )
                        .ToList();
                }
                if (
                    filtersCI.TryGetValue("vehiclevin", out var vehicleVinFilter)
                    && allowedColumns.Any(c =>
                        c.Equals("VehicleVin", StringComparison.OrdinalIgnoreCase)
                    )
                )
                {
                    var filterNoDiacritics = DiacriticUtils.RemoveDiacritics(
                        vehicleVinFilter.ToLower()
                    );
                    queryList = queryList
                        .Where(e =>
                            DiacriticUtils
                                .RemoveDiacritics(e.Vehicle.Vin.ToLower())
                                .Contains(filterNoDiacritics)
                        )
                        .ToList();
                }
            }

            var totalCount = queryList.Count;
            var items = queryList.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            return (items, totalCount);
        }
    }
}
