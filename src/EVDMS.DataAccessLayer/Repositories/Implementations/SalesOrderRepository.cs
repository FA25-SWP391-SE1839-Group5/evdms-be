using System.Linq.Expressions;
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

            // Custom search for DealerName, UserFullName, CustomerFullName, VehicleVin
            bool searchedDealerName = false,
                searchedUserFullName = false,
                searchedCustomerFullName = false,
                searchedVehicleVin = false;
            if (!string.IsNullOrWhiteSpace(search) && allowedColumns != null)
            {
                var searchLower = search.ToLower();
                searchedDealerName = allowedColumns.Contains("DealerName");
                searchedUserFullName = allowedColumns.Contains("UserFullName");
                searchedCustomerFullName = allowedColumns.Contains("CustomerFullName");
                searchedVehicleVin = allowedColumns.Contains("VehicleVin");
                if (
                    searchedDealerName
                    || searchedUserFullName
                    || searchedCustomerFullName
                    || searchedVehicleVin
                )
                {
                    query = query.Where(e =>
                        (searchedDealerName && e.Dealer.Name.ToLower().Contains(searchLower))
                        || (searchedUserFullName && e.User.FullName.ToLower().Contains(searchLower))
                        || (
                            searchedCustomerFullName
                            && e.Customer.FullName.ToLower().Contains(searchLower)
                        )
                        || (searchedVehicleVin && e.Vehicle.Vin.ToLower().Contains(searchLower))
                    );
                }
            }

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

            // Custom filter for DealerName, UserFullName, CustomerFullName, VehicleVin (case-insensitive)
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
                    filtersCI.TryGetValue("userfullname", out var userFullNameFilter)
                    && allowedColumns.Any(c =>
                        c.Equals("UserFullName", StringComparison.OrdinalIgnoreCase)
                    )
                )
                {
                    var filterLower = userFullNameFilter.ToLower();
                    query = query.Where(e => e.User.FullName.ToLower().Contains(filterLower));
                }
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
                    filtersCI.TryGetValue("vehiclevin", out var vehicleVinFilter)
                    && allowedColumns.Any(c =>
                        c.Equals("VehicleVin", StringComparison.OrdinalIgnoreCase)
                    )
                )
                {
                    var filterLower = vehicleVinFilter.ToLower();
                    query = query.Where(e => e.Vehicle.Vin.ToLower().Contains(filterLower));
                }
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
                !searchedDealerName
                && !searchedUserFullName
                && !searchedCustomerFullName
                && !searchedVehicleVin
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

            var totalCount = await query.CountAsync();
            var items = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            return (items, totalCount);
        }
    }
}
