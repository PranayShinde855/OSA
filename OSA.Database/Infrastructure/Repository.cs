using Microsoft.EntityFrameworkCore;
using OSA.Database.DBContext;

namespace OSA.Database.Infrastructure
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public readonly OSADbContext _context;
        public Repository(OSADbContext context)
        {
            this._context = context;
        }

        public T Add(T entity)
        {
            this._context.Set<T>().Add(entity);
            return entity;
        }

        public async Task<List<T>> GetAll()
        {
            return await this._context.Set<T>().ToListAsync();
        }
    }
}
