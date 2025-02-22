using FluentValidation;
using LegalexAccount.BLL.Services.MailSender;
using LegalexAccount.DAL;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


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

        public static void AddHandlerValidator(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviorService<,>));
        }

        public static void AddPresenceTracker(this IServiceCollection services)
        {
            services.AddSingleton<PresenceTracker>();
        }
    }
}
