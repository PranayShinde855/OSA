using System.Linq.Expressions;

namespace OSA.Database.Infrastructure
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        IQueryable<T> GetAllAsQueryableAsync(Expression<Func<T, bool>> prdicate = null);
        Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> prdicate = null, bool eager = false);
        Task<T> GetByIdAsync(int Id);
        Task<T> AddAsync(T entity);
        Task<T> Update(T entity);
        Task<bool> Delete(T entity);
    }
}
