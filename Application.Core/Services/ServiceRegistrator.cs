using Domain.Core.CaseAggregate;
using Domain.Core.OrderAggregate;
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
                dbContext.Database.Migrate();

            var userRoles = dbContext.UserRoles.ToDictionary(x => x.UserRoleId);
            var clientRoles = dbContext.ClientRoles.ToDictionary(x => x.ClientRoleId);
            var specialistRoles = dbContext.SpecialistRoles.ToDictionary(x => x.SpecialistRoleId);

            var test = userRoles[Utilities.Types.UserRole.Client];

            if (!dbContext.Specialists.Any())
            {
                var salt1 = GenerateDataService.GenerateSalt(32);
                var salt2 = GenerateDataService.GenerateSalt(32);

                dbContext.Specialists.AddRange(
                    new Specialist
                    {
                        Status = SpecialistStatus.Free,
                        Role = userRoles[Utilities.Types.UserRole.Specialist],
                        SpecialistRole = specialistRoles[Utilities.Types.SpecialistRole.TechnicalSpecialist],
                        Email = "support@legalex.by",
                        FirstName = "Тимофей",
                        LastName = "Липницкий",
                        PasswordHash = GenerateDataService.GenerateHash("1234dev!", salt1),
                        PasswordSalt = salt1
                    },
                    new Specialist
                    {
                        Status = SpecialistStatus.Free,
                        Role = userRoles[Utilities.Types.UserRole.Specialist],
                        SpecialistRole = specialistRoles[Utilities.Types.SpecialistRole.Director],
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
                        Role = userRoles[Utilities.Types.UserRole.Client],
                        ClientRole = clientRoles[Utilities.Types.ClientRole.Person],
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
                        Role = userRoles[Utilities.Types.UserRole.Client],
                        ClientRole = clientRoles[Utilities.Types.ClientRole.Person],
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
                        Role = userRoles[Utilities.Types.UserRole.Client],
                        ClientRole = clientRoles[Utilities.Types.ClientRole.Legal],
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
                        Role = userRoles[Utilities.Types.UserRole.Client],
                        ClientRole = clientRoles[Utilities.Types.ClientRole.Legal],
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
                        ClientType = clientRoles[Utilities.Types.ClientRole.Legal],
                        ServiceType = ServiceType.Mediation,
                        ClientName = "Иван Иванов",
                        Contact = "+375291112233",
                        Description = "Необходима консультация по жилищному вопросу."
                    },
                    new Order
                    {
                        CreatedAt = DateTime.UtcNow,
                        ClientType = clientRoles[Utilities.Types.ClientRole.Person],
                        ServiceType = ServiceType.ProtectionOfPersonalInformation,
                        ClientName = "ООО 'АльфаПром'",
                        Contact = "info@alfaprom.by",
                        Description = "Проверка договора аренды склада."
                    },
                    new Order
                    {
                        CreatedAt = DateTime.UtcNow,
                        ClientType = clientRoles[Utilities.Types.ClientRole.Person],
                        ServiceType = ServiceType.None,
                        ClientName = "Анна Сидорова",
                        Contact = "+375333334455",
                        Description = "Представительство в суде по делу о наследстве."
                    },
                    new Order
                    {
                        CreatedAt = DateTime.UtcNow,
                        ClientType = clientRoles[Utilities.Types.ClientRole.Person],
                        ServiceType = ServiceType.Finance,
                        ClientName = "Иван Иванов",
                        Contact = "+375291112233",
                        Description = "Необходима консультация по жилищному вопросу."
                    },
                    new Order
                    {
                        CreatedAt = DateTime.UtcNow,
                        ClientType = clientRoles[Utilities.Types.ClientRole.Legal],
                        ServiceType = ServiceType.OccupationalSafetyAndHealth,
                        ClientName = "ООО 'АльфаПром'",
                        Contact = "info@alfaprom.by",
                        Description = "Проверка договора аренды склада."
                    },
                    new Order
                    {
                        CreatedAt = DateTime.UtcNow,
                        ClientType = clientRoles[Utilities.Types.ClientRole.Person],
                        ServiceType = ServiceType.Mediation,
                        ClientName = "Анна Сидорова",
                        Contact = "+375333334455",
                        Description = "Представительство в суде по делу о наследстве."
                    },
                    new Order
                    {
                        CreatedAt = DateTime.UtcNow,
                        ClientType = clientRoles[Utilities.Types.ClientRole.Person],
                        ServiceType = ServiceType.ProtectionOfPersonalInformation,
                        ClientName = "Павел Корнеев",
                        Contact = "+375296660011",
                        Description = "Проверка договора купли-продажи авто."
                    },
                    new Order
                    {
                        CreatedAt = DateTime.UtcNow,
                        ClientType = clientRoles[Utilities.Types.ClientRole.Legal],
                        ServiceType = ServiceType.Finance,
                        ClientName = "ЧУП 'БизнесЭксперт'",
                        Contact = "consult@bizexp.by",
                        Description = "Консультация по вопросам налогового планирования."
                    },
                    new Order
                    {
                        CreatedAt = DateTime.UtcNow,
                        ClientType = clientRoles[Utilities.Types.ClientRole.Person],
                        ServiceType = ServiceType.None,
                        ClientName = "Дмитрий Шевцов",
                        Contact = "+375291223344",
                        Description = "Требуется представление интересов в административном процессе."
                    },
                    new Order
                    {
                        CreatedAt = DateTime.UtcNow,
                        ClientType = clientRoles[Utilities.Types.ClientRole.Legal],
                        ServiceType = ServiceType.HR,
                        ClientName = "ЗАО 'ЭнергияСвета'",
                        Contact = "legal@energosvet.by",
                        Description = "Анализ контракта с подрядчиком."
                    },
                    new Order
                    {
                        CreatedAt = DateTime.UtcNow,
                        ClientType = clientRoles[Utilities.Types.ClientRole.Person],
                        ServiceType = ServiceType.HRSupport,
                        ClientName = "Марина Лисовская",
                        Contact = "+375297775566",
                        Description = "Разъяснение по вопросам трудового законодательства."
                    },
                    new Order
                    {
                        CreatedAt = DateTime.UtcNow,
                        ClientType = clientRoles[Utilities.Types.ClientRole.Legal],
                        ServiceType = ServiceType.None,
                        ClientName = "ООО 'ЛогистикПро'",
                        Contact = "law@logistikpro.by",
                        Description = "Нужен юрист для судебного разбирательства с контрагентом."
                    },
                    new Order
                    {
                        CreatedAt = DateTime.UtcNow,
                        ClientType = clientRoles[Utilities.Types.ClientRole.Person],
                        ServiceType = ServiceType.Legal,
                        ClientName = "Олег Смирнов",
                        Contact = "+375295556677",
                        Description = "Проверка нотариального соглашения."
                    }
                    );

                dbContext.SaveChanges();
            }

            if (!dbContext.Cases.Any())
            {
                var clients = dbContext.Clients.Take(4).ToList();

                dbContext.Cases.AddRange(
                    new Case
                    {
                        StartDate = DateTime.Now.AddDays(-10),
                        EstimatedDaysToEnd = 15,
                        Customer = clients[0],
                        Description = "Согласование договора аренды",
                        IsArchived = false
                    },
                    new Case
                    {
                        StartDate = DateTime.Now.AddDays(-5),
                        EstimatedDaysToEnd = 20,
                        Customer = clients[1],
                        Description = "Юридическая помощь при расторжении брака",
                        IsArchived = false
                    },
                    new Case
                    {
                        StartDate = DateTime.Now,
                        EstimatedDaysToEnd = 10,
                        Customer = clients[2],
                        Description = "Регистрация новой компании",
                        IsArchived = false
                    },
                    new Case
                    {
                        StartDate = DateTime.Now.AddDays(-3),
                        EstimatedDaysToEnd = 5,
                        Customer = clients[3],
                        Description = "Подготовка искового заявления",
                        IsArchived = false
                    },
                    new Case
                    {
                        StartDate = DateTime.Now.AddDays(-20),
                        EstimatedDaysToEnd = 30,
                        Customer = clients[0],
                        Description = "Анализ рисков сделки",
                        IsArchived = true,
                        ArchivedAt = DateTime.Now.AddDays(-5)
                    },
                    new Case
                    {
                        StartDate = DateTime.Now.AddDays(-15),
                        EstimatedDaysToEnd = 7,
                        Customer = clients[1],
                        Description = "Составление устава для юр. лица",
                        IsArchived = false
                    },
                    new Case
                    {
                        StartDate = DateTime.Now.AddDays(-7),
                        EstimatedDaysToEnd = 14,
                        Customer = clients[2],
                        Description = "Налоговое консультирование",
                        IsArchived = false
                    },
                    new Case
                    {
                        StartDate = DateTime.Now.AddDays(-2),
                        EstimatedDaysToEnd = 21,
                        Customer = clients[3],
                        Description = "Проверка юридической чистоты недвижимости",
                        IsArchived = false
                    },
                    new Case
                    {
                        StartDate = DateTime.Now.AddDays(-1),
                        EstimatedDaysToEnd = 10,
                        Customer = clients[0],
                        Description = "Сопровождение сделки купли-продажи",
                        IsArchived = false
                    },
                    new Case
                    {
                        StartDate = DateTime.Now,
                        EstimatedDaysToEnd = 25,
                        Customer = clients[1],
                        Description = "Юридическая защита в суде",
                        IsArchived = false
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
