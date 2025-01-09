using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OSA.Database.Infrastructure;
using OSA.DomainEntities.Users;

namespace OSA.Database.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
    }
}
