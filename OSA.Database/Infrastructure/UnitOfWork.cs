using OSA.Database.DBContext;
using OSA.Database.Interfaces;
using OSA.Database.Repositories;

namespace OSA.Database.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OSADbContext _context;
        public IUserRepository UserRepository { get; }
        public UnitOfWork(OSADbContext context, IUserRepository userRepository)
        {
            this._context = context;
            UserRepository = userRepository;
        }

        public async Task<int> SaveChanges()
        {
            //try
            //{
                return await this._context.SaveChangesAsync();
            //}
            //catch(Exception ex)
            //{
            //    throw ex;
            //}
        }
    }
}
