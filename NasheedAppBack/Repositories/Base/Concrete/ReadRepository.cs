using Microsoft.EntityFrameworkCore;
using NasheedAppBack.Repositories.Base.Abstractions;
using System.Linq.Expressions;

namespace NasheedAppBack.Repositories.Base.Concrete
{
    public class ReadRepository<T> : IReadRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        public ReadRepository(AppDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll(bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            return query;
        }

        public IQueryable<T> GetAllWhere(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = Table.Where(method);
            if (!tracking)
                query = query.AsNoTracking();
            return query;
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = Table.Where(method);
            if (!tracking)
                query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync();
        }


        public async Task<T> GetAsync(Expression<Func<T, bool>> filter, params string[] includeProperties)
        {
            var query = _context.Set<T>().AsQueryable();

            if (includeProperties != null)
            {
                query = includeProperties.Aggregate(query, (current, include) => current.Include(include));
            }

            return await query.Where(filter).FirstOrDefaultAsync();
        }
    }
}
