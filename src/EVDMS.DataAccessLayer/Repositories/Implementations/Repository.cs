using System.Linq.Expressions;
using EVDMS.DataAccessLayer.Data;
using EVDMS.DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EVDMS.DataAccessLayer.Repositories.Implementations
{
    public class Repository<T> : IRepository<T>
        where T : class
    {
        protected readonly AppDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public Repository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public virtual async Task<T?> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<(IEnumerable<T> Items, int TotalCount)> GetAllAsync(
            int page,
            int pageSize,
            string? sortBy = null,
            string? sortOrder = null
        )
        {
            var query = _dbSet.AsQueryable();
            if (!string.IsNullOrEmpty(sortBy))
            {
                var prop = typeof(T)
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
            var totalCount = await query.CountAsync();
            var items = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            return (items, totalCount);
        }

        public virtual async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public virtual async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public virtual void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public virtual void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public virtual async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
