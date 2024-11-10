using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using NasheedAppBack.Repositories.Base.Abstractions;

namespace NasheedAppBack.Repositories.Base.Concrete
{
    public class WriteRepository<T> : IWriteRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        public WriteRepository(AppDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task<bool> AddAsync(T model)
        {
            EntityEntry<T> entry = await Table.AddAsync(model);
            return entry.State == EntityState.Added;
        }

        public async Task<T> AddEntityAsync(T model)
        {
            EntityEntry<T> entry = await Table.AddAsync(model);
            entry.State = EntityState.Added;
            return model;
        }


        public bool Remove(T model)
        {
            Table.Remove(model);
            return true;
        }

        public async Task<int> SaveAsync() => await _context.SaveChangesAsync();

        public bool Update(T model)
        {
            EntityEntry<T> entry = Table.Update(model);
            return entry.State == EntityState.Modified;
        }
    }
}
