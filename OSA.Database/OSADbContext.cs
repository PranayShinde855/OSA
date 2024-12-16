using Microsoft.EntityFrameworkCore;

namespace OSA.Database
{
    public class OSADbContext : DbContext
    {
        public OSADbContext(DbContextOptions options): base(options)
        {
            
        }


    }
}
