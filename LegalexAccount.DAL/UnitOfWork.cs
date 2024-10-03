using LegalexAccount.DAL.Models;
using LegalexAccount.DAL.Models.CaseAggregate;
using LegalexAccount.DAL.Models.OrderAggregate;
using LegalexAccount.DAL.Models.UserAggregate;
using LegalexAccount.DAL.Storage;
using LegalexAccount.DAL.Storage.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;


namespace LegalexAccount.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserRepository _userRepository;
        private readonly SpecialistRepository _specialistRepository;
        private readonly ClientRepository _clientRepository;
        private readonly OrderRepository _orderRepository;
        private readonly CaseRepository _caseRepository;
        public IUserRepository<User> Users { get => _userRepository; }
        public ISpecialistRepository Specialists { get => _specialistRepository; }
        public IClientRepository Clients { get => _clientRepository; }
        public IOrderRepository Orders { get => _orderRepository; }
        public ICaseRepository Cases { get => _caseRepository; }


        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _userRepository = new(dbContext);
            _specialistRepository = new(dbContext);
            _clientRepository = new(dbContext);
            _orderRepository = new(dbContext);
            _caseRepository = new(dbContext);
            _dbContext = dbContext;

            InitialDatabase();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            _dbContext.Dispose();
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
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
                        Email = "support@LegalexAccount.by",
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
                        Email = "v.vlasenkov@LegalexAccount.by",
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
