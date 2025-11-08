using System.Linq.Expressions;
using EVDMS.Common.Utils;
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

            // Use base repository's filtering and searching for other columns (excluding custom ones)
            query = ApplyFilters(
                query,
                filters,
                allowedColumns?.Where(c =>
                    !string.Equals(c, "CustomerFullName", StringComparison.OrdinalIgnoreCase)
                    && !string.Equals(c, "DealerName", StringComparison.OrdinalIgnoreCase)
                    && !string.Equals(c, "Content", StringComparison.OrdinalIgnoreCase)
                )
            );
            if (
                string.IsNullOrWhiteSpace(search)
                || allowedColumns == null
                || (
                    !allowedColumns.Contains("CustomerFullName")
                    && !allowedColumns.Contains("DealerName")
                    && !allowedColumns.Contains("Content")
                )
            )
            {
                query = ApplySearch(
                    query,
                    search,
                    allowedColumns?.Where(c =>
                        !string.Equals(c, "CustomerFullName", StringComparison.OrdinalIgnoreCase)
                        && !string.Equals(c, "DealerName", StringComparison.OrdinalIgnoreCase)
                        && !string.Equals(c, "Content", StringComparison.OrdinalIgnoreCase)
                    )
                );
            }

            // Materialize the query ONCE
            var queryList = await query.ToListAsync();

            // In-memory diacritic-insensitive search for CustomerFullName, DealerName, and Content
            if (
                !string.IsNullOrWhiteSpace(search)
                && allowedColumns != null
                && (
                    allowedColumns.Contains("CustomerFullName")
                    || allowedColumns.Contains("DealerName")
                    || allowedColumns.Contains("Content")
                )
            )
            {
                var searchNoDiacritics = DiacriticUtils.RemoveDiacritics(search.ToLower());
                queryList = queryList
                    .Where(e =>
                        (
                            allowedColumns.Contains("CustomerFullName")
                            && DiacriticUtils
                                .RemoveDiacritics(e.Customer.FullName.ToLower())
                                .Contains(searchNoDiacritics)
                        )
                        || (
                            allowedColumns.Contains("DealerName")
                            && DiacriticUtils
                                .RemoveDiacritics(e.Dealer.Name.ToLower())
                                .Contains(searchNoDiacritics)
                        )
                        || (
                            allowedColumns.Contains("Content")
                            && DiacriticUtils
                                .RemoveDiacritics(e.Content.ToLower())
                                .Contains(searchNoDiacritics)
                        )
                    )
                    .ToList();
            }

            // In-memory diacritic-insensitive filter for CustomerFullName, DealerName, and Content
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
                    filtersCI.TryGetValue("content", out var contentFilter)
                    && allowedColumns.Any(c =>
                        c.Equals("Content", StringComparison.OrdinalIgnoreCase)
                    )
                )
                {
                    var filterNoDiacritics = DiacriticUtils.RemoveDiacritics(
                        contentFilter.ToLower()
                    );
                    queryList = queryList
                        .Where(e =>
                            DiacriticUtils
                                .RemoveDiacritics(e.Content.ToLower())
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
