using OSA.Database.DBContext;
using OSA.Database.Interfaces;

namespace OSA.Database.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OSADbContext _context;
        public IUserRepository UserRepository { get; }
        public ICompanyRepository CompanyRepository { get; }
        public UnitOfWork(OSADbContext context, IUserRepository userRepository
            , ICompanyRepository companyRepository)
        {
            this._context = context;
            UserRepository = userRepository;
            CompanyRepository = companyRepository;
        }

        public async Task<int> SaveChanges()
        {
                return await this._context.SaveChangesAsync();
        }
    }
}
