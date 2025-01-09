using OSA.Database.DBContext;

namespace OSA.Database.Infrastructure
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly OSADbContext _context;
        public Repository(OSADbContext context)
        {
            this._context = context;
        }

        public T Add(T entity)
        {
            this._context.Set<T>().Add(entity);
            return entity;
        }
    }
}
