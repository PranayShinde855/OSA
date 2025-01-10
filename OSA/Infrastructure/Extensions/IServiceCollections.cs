using System.Configuration;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NetCore.AutoRegisterDi;
using OSA.Database.DBContext;
using OSA.Database.Infrastructure;
using OSA.Database.Interfaces;
using OSA.Database.Repositories;
using OSA.Services.Interfaces;
using OSA.Utility;

namespace OSA.API.Infrastructure.Extensions
{
    public static class IServiceCollections
    {
        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>))
                //.AddTransient<IUserRepository, typeof(UserRepository));
                .AddTransient<IUserRepository, UserRepository>();
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
            //services.AddDbContext<OSADbContext>(options => options.UseSqlServer(configuration.GetConnectionString(Constants.CONNNECTION_STRING), op =>
            //{
            //    op.CommandTimeout(1000000);
            //})
            //, ServiceLifetime.Scoped
            //);
            try
            {
                services.AddDbContext<OSADbContext>(options =>
                {
                    options.UseSqlServer(configuration.GetConnectionString(Constants.CONNNECTION_STRING), sqlOptions =>
                    {
                        sqlOptions.CommandTimeout(1000000);
                        sqlOptions.EnableRetryOnFailure(
                            maxRetryCount: 5,
                            maxRetryDelay: TimeSpan.FromSeconds(30),
                            errorNumbersToAdd: null
                        );
                    });
                }, ServiceLifetime.Scoped);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                Console.WriteLine($"Inner Exception: {ex.InnerException?.Message}");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}"); throw;
            }
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            
        }
        public static void GetAppSettingSection(this IServiceCollection services, IConfiguration configuration, out AppSettings appSettings)
        {
            var appSettingSection = configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingSection);
            appSettings = appSettingSection.Get<AppSettings>();
        }
    }
}
