using System.Configuration;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NetCore.AutoRegisterDi;
using OSA.Database;
using OSA.Database.Infrastructure;
using OSA.Services.Interfaces;
using OSA.Utility;

namespace OSA.API.Infrastructure.Extensions
{
    public static class IServiceCollections
    {
        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddTransient(typeof(IRepository), typeof(Repository));
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

            services.AddTransient(typeof(IUniOfWork), typeof(UnitOfWork));
        }
        public static void GetAppSettingSection(this IServiceCollection services, IConfiguration configuration, out AppSettings appSettings)
        {
            var appSettingSection = configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingSection);
            appSettings = appSettingSection.Get<AppSettings>();
        }
    }
}
