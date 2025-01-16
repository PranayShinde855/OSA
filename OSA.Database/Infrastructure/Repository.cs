using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using OSA.Database.DBContext;

namespace OSA.Database.Infrastructure
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public readonly OSADbContext _context;
        protected Repository(OSADbContext context)
        {
            _context = context;
        }

        public async Task<T> AddAsync(T entity)
        {
            var en = await _context.Set<T>().AddAsync(entity);
            //_context.SaveChanges();
            return en.Entity;
        }

        public async Task<bool> Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            return true;
        }

        public IQueryable<T> GetAllAsQueryableAsync(Expression<Func<T, bool>> predicate = null)
        {
            if(predicate == null)
            {
                return _context.Set<T>();
            }
            else
            {
                return _context.Set<T>().Where(predicate);
            }
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>> prdicate = null, bool eager = false)
        {
            return await Query(eager).FirstOrDefaultAsync(prdicate);  
        }

        public IQueryable<T> Query(bool eager = false)
        {
            var query = _context.Set<T>().AsQueryable();

            if (eager)
            {
                foreach (var property in _context.Model.FindEntityType(typeof(T)).GetNavigations())
                {
                    query = query.Include(property.Name);
                }
            }
            return query;
        }

        public async Task<T> Update(T entity)
        {
            _context.Set<T>().Update(entity);
            return entity;
        }
    }
}
