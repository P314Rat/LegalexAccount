using LegalexAccount.DAL.Models.CaseAggregate;
using LegalexAccount.DAL.Models.OrderAggregate;
using LegalexAccount.DAL.Models.UserAggregate;
using LegalexAccount.DAL.Repositories;
using LegalexAccount.DAL.Repositories.Contracts;
using LegalexAccount.Utility.Types;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;


namespace LegalexAccount.DAL
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private const string UNIT_OF_WORK_CONTEXT_NAME = "UnitOfWork";

        private readonly ApplicationDbContext _dbContext;
        private readonly UserRepository _userRepository;
        private readonly SpecialistRepository _specialistRepository;
        private readonly ClientRepository _clientRepository;
        private readonly PersonRepository _personRepository;
        private readonly LegalRepository _legalRepository;
        private readonly OrderRepository _orderRepository;
        private readonly CaseRepository _caseRepository;

        public IUserRepository Users { get => _userRepository; }
        public IRepository<Specialist, Guid> Specialists { get => _specialistRepository; }
        public IRepository<Client, Guid> Clients { get => _clientRepository; }
        public IRepository<Person, Guid> Individuals { get => _personRepository; }
        public IRepository<Legal, Guid> LegalEntities { get => _legalRepository; }
        public IRepository<Order, int> Orders { get => _orderRepository; }
        public IRepository<Case, int> Cases { get => _caseRepository; }


        public UnitOfWork(IApplicationDbContextFactory dbFactory)
        {
            _userRepository = new(dbFactory);
            _specialistRepository = new(dbFactory);
            _clientRepository = new(dbFactory);
            _personRepository = new(dbFactory);
            _legalRepository = new(dbFactory);
            _orderRepository = new(dbFactory);
            _caseRepository = new(dbFactory);
            _dbContext = dbFactory.CreateDbContext(UNIT_OF_WORK_CONTEXT_NAME);

            InitialDatabase();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
            GC.SuppressFinalize(this);
        }

        private void InitialDatabase()
        {
            if (_dbContext.Database.GetPendingMigrations().Any())
                _dbContext.Database.Migrate();

            if (!_dbContext.Specialists.Any())
            {
                var salt = CreateSalt(32);
                _dbContext.Specialists.AddRange(
                    new Specialist
                    {
                        Status = SpecialistStatus.Free,
                        Role = SpecialistRole.Technical,
                        Email = "support@legalex.by",
                        PasswordHash = GenerateHash("1234dev!", salt),
                        PasswordSalt = salt,
                        FirstName = "Тимофей",
                        LastName = "Липницкий",
                    });

                salt = CreateSalt(32);
                _dbContext.Specialists.AddRange(
                    new Specialist
                    {
                        Status = SpecialistStatus.Free,
                        Role = SpecialistRole.Director,
                        Email = "vv95@bk.ru",
                        PasswordHash = GenerateHash("Peredovaya15!", salt),
                        PasswordSalt = salt,
                        FirstName = "Владислав",
                        LastName = "Власенков",
                    });
            }

            _dbContext.SaveChanges();
        }

        private string CreateSalt(int size)
        {
            var rng = new RNGCryptoServiceProvider();
            var buffer = new byte[size];
            rng.GetBytes(buffer);

            return Convert.ToBase64String(buffer);
        }
        private string GenerateHash(string input, string salt)
        {
            using (var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(salt)))
            {
                var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(input));

                return Convert.ToBase64String(hash);
            }
        }
    }
}
