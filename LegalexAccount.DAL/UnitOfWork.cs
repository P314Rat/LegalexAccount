using LegalexAccount.DAL.Models.AccountAggregate;
using LegalexAccount.DAL.Models.CaseAggregate;
using LegalexAccount.DAL.Models.OrderAggregate;
using LegalexAccount.DAL.Models.UserAggregate;
using LegalexAccount.DAL.Repositories;
using LegalexAccount.DAL.Repositories.Contracts;


namespace LegalexAccount.DAL
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly UserRepository _userRepository;
        private readonly SpecialistRepository _specialistRepository;
        private readonly ClientRepository _clientRepository;
        private readonly PersonRepository _personRepository;
        private readonly LegalRepository _legalRepository;
        private readonly OrderRepository _orderRepository;
        private readonly CaseRepository _caseRepository;
        private readonly PasswordResetTokenRepository _passwordResetTokenRepository;

        public IUserRepository<User> Users { get => _userRepository; }
        public IRepository<Specialist, Guid> Specialists { get => _specialistRepository; }
        public IRepository<Client, Guid> Clients { get => _clientRepository; }
        public IRepository<Person, Guid> Individuals { get => _personRepository; }
        public IRepository<Legal, Guid> LegalEntities { get => _legalRepository; }
        public IRepository<Order, int> Orders { get => _orderRepository; }
        public IRepository<Case, int> Cases { get => _caseRepository; }
        public IRepository<PasswordResetToken, int> PasswordResetTokens { get => _passwordResetTokenRepository; }

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _userRepository = new(dbContext);
            _specialistRepository = new(dbContext);
            _clientRepository = new(dbContext);
            _personRepository = new(dbContext);
            _legalRepository = new(dbContext);
            _orderRepository = new(dbContext);
            _caseRepository = new(dbContext);
            _passwordResetTokenRepository = new(dbContext);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
