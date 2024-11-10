using System.Linq.Expressions;

namespace NasheedAppBack.Repositories.Base.Abstractions
{
    public interface IReadRepository<T> : IRepository<T> where T : class
    {
        IQueryable<T> GetAll(bool tracking = true);
        IQueryable<T> GetAllWhere(Expression<Func<T, bool>> method, bool tracking = true);
        Task<T> GetAsync(Expression<Func<T, bool>> method, bool tracking = true);
        Task<T> GetAsync(Expression<Func<T, bool>> filter, params string[] includeProperties);
    }
}
