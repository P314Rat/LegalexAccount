using Domain.Core.OrderAggregate;
using Domain.Core.UserAggregate;
using Infrastructure;
using Infrastructure.Contracts;
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
                dbContext.Database.Migrate();

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
                        FirstName = "Тимофей",
                        LastName = "Липницкий",
                        PasswordHash = GenerateDataService.GenerateHash("1234dev!", salt1),
                        PasswordSalt = salt1
                    },
                    new Specialist
                    {
                        Status = SpecialistStatus.Free,
                        Role = SpecialistType.Director,
                        Email = "vv95@bk.ru",
                        FirstName = "Владислав",
                        LastName = "Власенков",
                        PasswordHash = GenerateDataService.GenerateHash("Peredovaya15!", salt2),
                        PasswordSalt = salt2
                    }
                );

                dbContext.SaveChanges();
            }

            if (!dbContext.Clients.Any())
            {
                var salt1 = GenerateDataService.GenerateSalt(32);
                var salt2 = GenerateDataService.GenerateSalt(32);
                var salt3 = GenerateDataService.GenerateSalt(32);
                var salt4 = GenerateDataService.GenerateSalt(32);

                dbContext.Clients.AddRange(
                    new Person
                    {
                        Email = "ivan.petrov@example.com",
                        FirstName = "Иван",
                        LastName = "Петров",
                        DateOfBirth = new DateTime(1985, 5, 23),
                        PassportNumber = "AB1234567",
                        IssuingAuthority = "Минский РОВД",
                        IssueDate = new DateTime(2005, 8, 12),
                        TaxIdentificationNumber = "123456789",
                        RegistrationAddress = "Минск, ул. Ленина, 10",
                        ResidentialAddress = "Минск, ул. Пушкина, 5",
                        PasswordHash = GenerateDataService.GenerateHash("1234dev!", salt1),
                        PasswordSalt = salt1
                    },
                    new Person
                    {
                        Email = "anna.ivanova@example.com",
                        FirstName = "Анна",
                        LastName = "Иванова",
                        DateOfBirth = new DateTime(1990, 7, 12),
                        PassportNumber = "CD9876543",
                        IssuingAuthority = "Гомельский РОВД",
                        IssueDate = new DateTime(2010, 6, 15),
                        RegistrationAddress = "Гомель, ул. Советская, 15",
                        PasswordHash = GenerateDataService.GenerateHash("1234dev!", salt2),
                        PasswordSalt = salt2
                    },
                    new Legal
                    {
                        Email = "company1@example.com",
                        FirstName = "ООО",
                        LastName = "ТехноПроф",
                        OrganizationName = "ТехноПроф",
                        LegalAddress = "Минск, пр-т Независимости, 100",
                        LegalID = "123456789",
                        BankAccountNumber = "BY12TECH1000000000000000",
                        BankName = "Беларусбанк",
                        BankAddress = "Минск, ул. Кирова, 2",
                        BankIdenticationCode = "BIC123456",
                        PositionHeld = "Генеральный директор",
                        Powers = "На основании устава",
                        PasswordHash = GenerateDataService.GenerateHash("1234dev!", salt3),
                        PasswordSalt = salt3
                    },
                    new Legal
                    {
                        Email = "company2@example.com",
                        FirstName = "ЗАО",
                        LastName = "СтройГарант",
                        OrganizationName = "СтройГарант",
                        LegalAddress = "Брест, ул. Победы, 25",
                        LegalID = "987654321",
                        BankAccountNumber = "BY98BUILD1000000000000000",
                        BankName = "Приорбанк",
                        BankAddress = "Брест, ул. Ленина, 10",
                        BankIdenticationCode = "BIC987654",
                        PositionHeld = "Директор",
                        Powers = "По доверенности №123 от 01.01.2024",
                        PasswordHash = GenerateDataService.GenerateHash("1234dev!", salt4),
                        PasswordSalt = salt4
                    }
                );

                dbContext.SaveChanges();
            }

            if (!dbContext.Orders.Any())
            {
                dbContext.Orders.AddRange(
                    new Order
                    {
                        CreatedAt = DateTime.UtcNow,
                        ClientType = ClientType.Legal,
                        Service = ServiceType.Mediation,
                        ClientName = "Иван Иванов",
                        Contact = "+375291112233",
                        Description = "Необходима консультация по жилищному вопросу."
                    },
                    new Order
                    {
                        CreatedAt = DateTime.UtcNow,
                        ClientType = ClientType.Person,
                        Service = ServiceType.ProtectionOfPersonalInformation,
                        ClientName = "ООО 'АльфаПром'",
                        Contact = "info@alfaprom.by",
                        Description = "Проверка договора аренды склада."
                    },
                    new Order
                    {
                        CreatedAt = DateTime.UtcNow,
                        ClientType = ClientType.Person,
                        Service = ServiceType.NonSelected,
                        ClientName = "Анна Сидорова",
                        Contact = "+375333334455",
                        Description = "Представительство в суде по делу о наследстве."
                    },
                    new Order
                    {
                        CreatedAt = DateTime.UtcNow,
                        ClientType = ClientType.Person,
                        Service = ServiceType.Finance,
                        ClientName = "Иван Иванов",
                        Contact = "+375291112233",
                        Description = "Необходима консультация по жилищному вопросу."
                    },
                    new Order
                    {
                        CreatedAt = DateTime.UtcNow,
                        ClientType = ClientType.Legal,
                        Service = ServiceType.OccupationalSafetyAndHealth,
                        ClientName = "ООО 'АльфаПром'",
                        Contact = "info@alfaprom.by",
                        Description = "Проверка договора аренды склада."
                    },
                    new Order
                    {
                        CreatedAt = DateTime.UtcNow,
                        ClientType = ClientType.Person,
                        Service = ServiceType.Mediation,
                        ClientName = "Анна Сидорова",
                        Contact = "+375333334455",
                        Description = "Представительство в суде по делу о наследстве."
                    },
                    new Order
                    {
                        CreatedAt = DateTime.UtcNow,
                        ClientType = ClientType.Person,
                        Service = ServiceType.ProtectionOfPersonalInformation,
                        ClientName = "Павел Корнеев",
                        Contact = "+375296660011",
                        Description = "Проверка договора купли-продажи авто."
                    },
                    new Order
                    {
                        CreatedAt = DateTime.UtcNow,
                        ClientType = ClientType.Person,
                        Service = ServiceType.Finance,
                        ClientName = "ЧУП 'БизнесЭксперт'",
                        Contact = "consult@bizexp.by",
                        Description = "Консультация по вопросам налогового планирования."
                    },
                    new Order
                    {
                        CreatedAt = DateTime.UtcNow,
                        ClientType = ClientType.Legal,
                        Service = ServiceType.NonSelected,
                        ClientName = "Дмитрий Шевцов",
                        Contact = "+375291223344",
                        Description = "Требуется представление интересов в административном процессе."
                    },
                    new Order
                    {
                        CreatedAt = DateTime.UtcNow,
                        ClientType = ClientType.Person,
                        Service = ServiceType.HR,
                        ClientName = "ЗАО 'ЭнергияСвета'",
                        Contact = "legal@energosvet.by",
                        Description = "Анализ контракта с подрядчиком."
                    },
                    new Order
                    {
                        CreatedAt = DateTime.UtcNow,
                        ClientType = ClientType.Person,
                        Service = ServiceType.HRSupport,
                        ClientName = "Марина Лисовская",
                        Contact = "+375297775566",
                        Description = "Разъяснение по вопросам трудового законодательства."
                    },
                    new Order
                    {
                        CreatedAt = DateTime.UtcNow,
                        ClientType = ClientType.Person,
                        Service = ServiceType.NonSelected,
                        ClientName = "ООО 'ЛогистикПро'",
                        Contact = "law@logistikpro.by",
                        Description = "Нужен юрист для судебного разбирательства с контрагентом."
                    },
                    new Order
                    {
                        CreatedAt = DateTime.UtcNow,
                        ClientType = ClientType.Legal,
                        Service = ServiceType.Legal,
                        ClientName = "Олег Смирнов",
                        Contact = "+375295556677",
                        Description = "Проверка нотариального соглашения."
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
