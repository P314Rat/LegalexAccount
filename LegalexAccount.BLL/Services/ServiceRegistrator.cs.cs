using LegalexAccount.DAL;
using LegalexAccount.DAL.Models;
using LegalexAccount.DAL.Storage;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace LegalexAccount.BLL.Services
{
    public static class ServiceRegistrator
    {
        public static void AddApplicationDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            }, ServiceLifetime.Transient);
        }

        public static void AddUnitOfWork(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}
