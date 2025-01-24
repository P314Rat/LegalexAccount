using LegalexAccount.BLL.Services.MailSender;
using LegalexAccount.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
            });
        }

        public static void AddUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public static void AddMailService(this IServiceCollection services, IConfigurationSection configurationSection)
        {
            services.Configure<MailSettings>(configurationSection);
            services.AddTransient<IMailService, MailService>();
        }
    }
}
