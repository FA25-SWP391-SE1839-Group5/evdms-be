using System.Globalization;
using System.Linq.Expressions;
using System.Text;
using EVDMS.Common.Utils;
using EVDMS.DataAccessLayer.Data;
using EVDMS.DataAccessLayer.Entities;
using EVDMS.DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EVDMS.DataAccessLayer.Repositories.Implementations
{
    public class TestDriveRepository : Repository<TestDrive>, ITestDriveRepository
    {
        public TestDriveRepository(AppDbContext context)
            : base(context) { }

        public override async Task<(IEnumerable<TestDrive> Items, int TotalCount)> GetAllAsync(
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
                .Include(td => td.Customer)
                .Include(td => td.Dealer)
                .Include(td => td.Vehicle)
                .AsQueryable();

            // Apply filters first
            query = ApplyFilters(
                query,
                filters,
                allowedColumns?.Where(c =>
                    !string.Equals(c, "CustomerFullName", StringComparison.OrdinalIgnoreCase)
                    && !string.Equals(c, "DealerName", StringComparison.OrdinalIgnoreCase)
                    && !string.Equals(c, "VehicleVin", StringComparison.OrdinalIgnoreCase)
                )
            );

            // Custom filter for CustomerFullName, DealerName, VehicleVin (case-insensitive)
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

            // Custom sort for CustomerFullName, DealerName, VehicleVin
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

            // Custom search for CustomerFullName, DealerName, VehicleVin
            bool searchedCustomerFullName = false,
                searchedDealerName = false,
                searchedVehicleVin = false;
            if (!string.IsNullOrWhiteSpace(search) && allowedColumns != null)
            {
                var searchLower = DiacriticUtils.RemoveDiacritics(search.ToLower());
                searchedCustomerFullName = allowedColumns.Contains("CustomerFullName");
                searchedDealerName = allowedColumns.Contains("DealerName");
                searchedVehicleVin = allowedColumns.Contains("VehicleVin");
                if (searchedCustomerFullName || searchedDealerName || searchedVehicleVin)
                {
                    var items = await query.ToListAsync();
                    items = items
                        .Where(e =>
                            (
                                searchedCustomerFullName
                                && DiacriticUtils
                                    .RemoveDiacritics(e.Customer.FullName.ToLower())
                                    .Contains(searchLower)
                            )
                            || (
                                searchedDealerName
                                && DiacriticUtils
                                    .RemoveDiacritics(e.Dealer.Name.ToLower())
                                    .Contains(searchLower)
                            )
                            || (searchedVehicleVin && e.Vehicle.Vin.ToLower().Contains(searchLower))
                        )
                        .ToList();
                    var totalCount = items.Count;
                    var pagedItems = items.Skip((page - 1) * pageSize).Take(pageSize).ToList();
                    return (pagedItems, totalCount);
                }
            }

            // Use base repository's searching for other columns (excluding custom ones)
            if (!searchedCustomerFullName && !searchedDealerName && !searchedVehicleVin)
            {
                query = ApplySearch(
                    query,
                    search,
                    allowedColumns?.Where(c =>
                        !string.Equals(c, "CustomerFullName", StringComparison.OrdinalIgnoreCase)
                        && !string.Equals(c, "DealerName", StringComparison.OrdinalIgnoreCase)
                        && !string.Equals(c, "VehicleVin", StringComparison.OrdinalIgnoreCase)
                    )
                );
            }

            var totalCountDb = await query.CountAsync();
            var itemsDb = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            return (itemsDb, totalCountDb);
        }
    }
}
