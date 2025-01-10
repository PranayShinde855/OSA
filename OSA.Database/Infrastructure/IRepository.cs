namespace OSA.Database.Infrastructure
{
    public interface IRepository<T> where T : class
    {
        T Add(T entity);
        Task<List<T>> GetAll();
    }
}
