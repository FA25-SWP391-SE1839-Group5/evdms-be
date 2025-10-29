using System.Linq.Expressions;
using EVDMS.DataAccessLayer.Data;
using EVDMS.DataAccessLayer.Entities;
using EVDMS.DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EVDMS.DataAccessLayer.Repositories.Implementations
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context)
            : base(context) { }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context
                .Users.Include(u => u.Dealer)
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<bool> ExistsByEmailAsync(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email);
        }

        public override async Task<User?> GetByIdAsync(Guid id)
        {
            return await _context.Users.Include(u => u.Dealer).FirstOrDefaultAsync(u => u.Id == id);
        }

        public override async Task<(IEnumerable<User> Items, int TotalCount)> GetAllAsync(
            int page,
            int pageSize,
            string? sortBy = null,
            string? sortOrder = null,
            string? search = null,
            Dictionary<string, string>? filters = null,
            IEnumerable<string>? allowedColumns = null
        )
        {
            var query = _context.Users.Include(u => u.Dealer).AsQueryable();
            if (filters != null && allowedColumns != null)
            {
                foreach (var filter in filters)
                {
                    var allowedCol = allowedColumns.FirstOrDefault(c =>
                        string.Equals(c, filter.Key, StringComparison.OrdinalIgnoreCase)
                    );
                    if (allowedCol != null)
                    {
                        var property = typeof(User).GetProperty(allowedCol);
                        if (property != null)
                        {
                            var parameter = Expression.Parameter(typeof(User), "e");
                            var propertyAccess = Expression.Property(parameter, property);
                            Expression equals;
                            if (property.PropertyType == typeof(string))
                            {
                                var toLowerMethod = typeof(string).GetMethod(
                                    "ToLower",
                                    Type.EmptyTypes
                                );
                                var propertyToLower = Expression.Call(
                                    propertyAccess,
                                    toLowerMethod!
                                );
                                var filterValue = Expression.Constant(
                                    filter.Value.ToLower(),
                                    typeof(string)
                                );
                                equals = Expression.Equal(propertyToLower, filterValue);
                            }
                            else if (property.PropertyType.IsEnum)
                            {
                                var enumValue = Enum.Parse(
                                    property.PropertyType,
                                    filter.Value,
                                    true
                                );
                                var filterValue = Expression.Constant(enumValue);
                                equals = Expression.Equal(propertyAccess, filterValue);
                            }
                            else if (
                                property.PropertyType == typeof(Guid)
                                || property.PropertyType == typeof(Guid?)
                            )
                            {
                                var guidValue = Guid.Parse(filter.Value);
                                var filterValue = Expression.Constant(
                                    guidValue,
                                    property.PropertyType
                                );
                                equals = Expression.Equal(propertyAccess, filterValue);
                            }
                            else
                            {
                                var filterValue = Expression.Constant(
                                    Convert.ChangeType(filter.Value, property.PropertyType)
                                );
                                equals = Expression.Equal(propertyAccess, filterValue);
                            }
                            var lambda = Expression.Lambda<Func<User, bool>>(equals, parameter);
                            query = query.Where(lambda);
                        }
                    }
                }
            }

            // Apply search
            if (!string.IsNullOrWhiteSpace(search) && allowedColumns != null)
            {
                System.Linq.Expressions.Expression? searchExpression = null;
                var parameter = Expression.Parameter(typeof(User), "e");
                var toLowerMethod = typeof(string).GetMethod("ToLower", Type.EmptyTypes);
                var searchValue = Expression.Constant(search.ToLower());
                foreach (var col in allowedColumns)
                {
                    var property = typeof(User).GetProperty(col);
                    if (property != null && property.PropertyType == typeof(string))
                    {
                        var propertyAccess = Expression.Property(parameter, property);
                        var propertyToLower = Expression.Call(propertyAccess, toLowerMethod!);
                        var containsMethod = typeof(string).GetMethod(
                            "Contains",
                            new[] { typeof(string) }
                        );
                        var contains = Expression.Call(
                            propertyToLower,
                            containsMethod!,
                            searchValue
                        );
                        searchExpression =
                            searchExpression == null
                                ? contains
                                : System.Linq.Expressions.Expression.OrElse(
                                    searchExpression,
                                    contains
                                );
                    }
                }
                if (searchExpression != null)
                {
                    var lambda = Expression.Lambda<Func<User, bool>>(searchExpression, parameter);
                    query = query.Where(lambda);
                }
            }

            // Sorting
            if (!string.IsNullOrEmpty(sortBy))
            {
                var prop = typeof(User)
                    .GetProperties()
                    .FirstOrDefault(p =>
                        string.Equals(p.Name, sortBy, StringComparison.OrdinalIgnoreCase)
                    );
                if (prop != null)
                {
                    var actualSortBy = prop.Name;
                    if (string.Equals(sortOrder, "desc", StringComparison.OrdinalIgnoreCase))
                        query = query.OrderByDescending(e => EF.Property<object>(e, actualSortBy));
                    else
                        query = query.OrderBy(e => EF.Property<object>(e, actualSortBy));
                }
            }
            else
            {
                query = query.OrderBy(e => EF.Property<object>(e, "Id"));
            }
            var totalCount = await query.CountAsync();
            var items = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            return (items, totalCount);
        }
    }
}
