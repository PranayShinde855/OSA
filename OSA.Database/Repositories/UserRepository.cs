using OSA.Database.DBContext;
using OSA.Database.Infrastructure;
using OSA.Database.Interfaces;
using OSA.DomainEntities.Users;

namespace OSA.Database.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(OSADbContext context) : base(context)
        {
        }
    }
}
