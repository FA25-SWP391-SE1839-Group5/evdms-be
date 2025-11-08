using System.Linq.Expressions;
using EVDMS.Common.Helpers;
using EVDMS.Common.Utils;
using EVDMS.DataAccessLayer.Data;
using EVDMS.DataAccessLayer.Entities;
using EVDMS.DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EVDMS.DataAccessLayer.Repositories.Implementations
{
    public class QuotationRepository : Repository<Quotation>, IQuotationRepository
    {
        public QuotationRepository(AppDbContext context)
            : base(context) { }

        public override async Task<(IEnumerable<Quotation> Items, int TotalCount)> GetAllAsync(
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
                .Include(q => q.Dealer)
                .Include(q => q.User)
                .Include(q => q.Customer)
                .Include(q => q.Variant)
                .AsQueryable();

            // Custom search for DealerName, UserFullName, CustomerFullName, VariantName
            bool searchedDealerName = false,
                searchedUserFullName = false,
                searchedCustomerFullName = false,
                searchedVariantName = false;
            if (!string.IsNullOrWhiteSpace(search) && allowedColumns != null)
            {
                var searchLower = search.ToLower();
                var searchNoDiacritics = DiacriticUtils.RemoveDiacritics(searchLower);
                searchedDealerName = allowedColumns.Contains("DealerName");
                searchedUserFullName = allowedColumns.Contains("UserFullName");
                searchedCustomerFullName = allowedColumns.Contains("CustomerFullName");
                searchedVariantName = allowedColumns.Contains("VariantName");
                if (
                    searchedDealerName
                    || searchedUserFullName
                    || searchedCustomerFullName
                    || searchedVariantName
                )
                {
                    // If searching CustomerFullName, do not restrict SQL query by other columns
                    if (!searchedCustomerFullName)
                    {
                        query = query.Where(e =>
                            (searchedDealerName && e.Dealer.Name.ToLower().Contains(searchLower))
                            || (
                                searchedUserFullName
                                && e.User.FullName.ToLower().Contains(searchLower)
                            )
                            || (
                                searchedVariantName
                                && e.Variant.Name.ToLower().Contains(searchLower)
                            )
                        );
                    }
                    // Otherwise, fetch all and filter in memory
                }
            }

            // Custom sort for DealerName, UserFullName, CustomerFullName, VariantName
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
                else if (string.Equals(sortBy, "VariantName", StringComparison.OrdinalIgnoreCase))
                {
                    query = string.Equals(sortOrder, "desc", StringComparison.OrdinalIgnoreCase)
                        ? query.OrderByDescending(e => e.Variant.Name)
                        : query.OrderBy(e => e.Variant.Name);
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

            // Custom filter for DealerName, UserFullName, CustomerFullName, VariantName (case-insensitive)
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
                    filtersCI.TryGetValue("variantname", out var variantNameFilter)
                    && allowedColumns.Any(c =>
                        c.Equals("VariantName", StringComparison.OrdinalIgnoreCase)
                    )
                )
                {
                    var filterLower = variantNameFilter.ToLower();
                    query = query.Where(e => e.Variant.Name.ToLower().Contains(filterLower));
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
                    && !string.Equals(c, "VariantName", StringComparison.OrdinalIgnoreCase)
                )
            );
            if (
                !searchedDealerName
                && !searchedUserFullName
                && !searchedCustomerFullName
                && !searchedVariantName
            )
            {
                query = ApplySearch(
                    query,
                    search,
                    allowedColumns?.Where(c =>
                        !string.Equals(c, "DealerName", StringComparison.OrdinalIgnoreCase)
                        && !string.Equals(c, "UserFullName", StringComparison.OrdinalIgnoreCase)
                        && !string.Equals(c, "CustomerFullName", StringComparison.OrdinalIgnoreCase)
                        && !string.Equals(c, "VariantName", StringComparison.OrdinalIgnoreCase)
                    )
                );
            }

            // Materialize the query
            var queryList = await query.ToListAsync();

            // In-memory filter for diacritic-insensitive CustomerFullName search
            if (
                !string.IsNullOrWhiteSpace(search)
                && allowedColumns != null
                && searchedCustomerFullName
            )
            {
                var searchNoDiacritics = DiacriticUtils.RemoveDiacritics(search.ToLower());
                queryList = queryList
                    .Where(e =>
                        DiacriticUtils
                            .RemoveDiacritics(e.Customer.FullName.ToLower())
                            .Contains(searchNoDiacritics)
                        || (
                            searchedDealerName && e.Dealer.Name.ToLower().Contains(search.ToLower())
                        )
                        || (
                            searchedUserFullName
                            && e.User.FullName.ToLower().Contains(search.ToLower())
                        )
                        || (
                            searchedVariantName
                            && e.Variant.Name.ToLower().Contains(search.ToLower())
                        )
                    )
                    .ToList();
            }
            // In-memory filter for diacritic-insensitive CustomerFullName filter
            if (
                filters != null
                && allowedColumns != null
                && filters.TryGetValue("customerfullname", out var customerFullNameFilter)
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

            var totalCount = queryList.Count;
            var items = queryList.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            return (items, totalCount);
        }
    }
}
