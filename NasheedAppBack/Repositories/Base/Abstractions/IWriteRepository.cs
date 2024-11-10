namespace NasheedAppBack.Repositories.Base.Abstractions
{
    public interface IWriteRepository<T> : IRepository<T> where T : class
    {
        Task<bool> AddAsync(T model);
        Task<T> AddEntityAsync(T model);
        bool Remove(T model);
        bool Update(T model);
        Task<int> SaveAsync();
    }
}
