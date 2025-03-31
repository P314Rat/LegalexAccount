using Domain.Core.UserAggregate;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Utilities.StaticServices;
using Utilities.Types;


namespace Application.Core.Services
{
    public static class ServiceRegistrator
    {
        public static void AddApplicationDbContext(this IServiceCollection services, string? connectionString)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            using var scope = services.BuildServiceProvider().CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            if (dbContext.Database.GetPendingMigrations().Any())
            {
                dbContext.Database.Migrate();
            }

            if (!dbContext.Specialists.Any())
            {
                var salt1 = GenerateDataService.GenerateSalt(32);
                var salt2 = GenerateDataService.GenerateSalt(32);

                dbContext.Specialists.AddRange(
                    new Specialist
                    {
                        Status = SpecialistStatus.Free,
                        Role = SpecialistType.Technical,
                        Email = "support@legalex.by",
                        PasswordHash = GenerateDataService.GenerateHash("1234dev!", salt1),
                        PasswordSalt = salt1,
                        FirstName = "Тимофей",
                        LastName = "Липницкий",
                    },
                    new Specialist
                    {
                        Status = SpecialistStatus.Free,
                        Role = SpecialistType.Director,
                        Email = "vv95@bk.ru",
                        PasswordHash = GenerateDataService.GenerateHash("Peredovaya15!", salt2),
                        PasswordSalt = salt2,
                        FirstName = "Владислав",
                        LastName = "Власенков",
                    }
                );

                dbContext.SaveChanges();
            }
        }

        public static void AddUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public static void AddAutomapper(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
