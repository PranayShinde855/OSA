using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
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

        public async Task<T> AddAsync(T entity)
        {
            await this._context.Set<T>().AddAsync(entity);
            return entity;
        }

        public async Task<bool> Delete(T entity)
        {
            this._context.Set<T>().Remove(entity);
            return true;
        }

        public IQueryable<T> GetAllAsQueryableAsync(Expression<Func<T, bool>> predicate = null)
        {
            if(predicate == null)
            {
                return this._context.Set<T>();
            }
            else
            {
                return this._context.Set<T>().Where(predicate);
            }
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await this._context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await this._context.Set<T>().FindAsync(id);
        }

        public async Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> prdicate = null, bool eager = false)
        {
            return await Query(eager).FirstOrDefaultAsync(prdicate);  
        }

        public IQueryable<T> Query(bool eager = false)
        {
            var query = this._context.Set<T>().AsQueryable();

            if (eager)
            {
                foreach (var property in this._context.Model.FindEntityType(typeof(T)).GetNavigations())
                {
                    query = query.Include(property.Name);
                }
            }
            return query;
        }

        public async Task<T> Update(T entity)
        {
            this._context.Set<T>().Update(entity);
            return entity;
        }
    }
}
