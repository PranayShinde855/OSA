using System.Reflection;
using Microsoft.EntityFrameworkCore;
using NetCore.AutoRegisterDi;
using OSA.Database;
using OSA.Services.Interfaces;
using OSA.Utility;

namespace OSA.API.Infrastructure.Extensions
{
    public static class IServiceCollections
    {
        public static void RegisterRepositories(this IServiceCollection services)
        {
            //services.AddTransient(typeof(), typeof());
        }

        public static void RegisterServices(this IServiceCollection services)
        {
            var assembliesToScan = new[]
            {
                Assembly.GetExecutingAssembly(),
                Assembly.GetAssembly(typeof(IBaseService))
            };

            services.RegisterAssemblyPublicNonGenericClasses(assembliesToScan)
                .Where(c => c.Name.EndsWith("Service"))
                .AsPublicImplementedInterfaces();
        }

        public static void ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<OSADbContext>(options => options.UseSqlServer(configuration.GetConnectionString(Constants.CONNNECTION_STRING), op =>
            {
                op.CommandTimeout(1000000);
            }));
        }
    }
}
