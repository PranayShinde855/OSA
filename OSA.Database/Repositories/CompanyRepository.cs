using OSA.Database.DBContext;
using OSA.Database.Infrastructure;
using OSA.Database.Interfaces;
using OSA.DomainEntities;

namespace OSA.Database.Repositories
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        public CompanyRepository(OSADbContext context) : base(context)
        {
        }
    }
}
