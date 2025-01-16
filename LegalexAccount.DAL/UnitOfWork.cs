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

        public IUserRepository Users { get => _userRepository; }
        public IRepository<Specialist, Guid> Specialists { get => _specialistRepository; }
        public IRepository<Client, Guid> Clients { get => _clientRepository; }
        public IRepository<Person, Guid> Individuals { get => _personRepository; }
        public IRepository<Legal, Guid> LegalEntities { get => _legalRepository; }
        public IRepository<Order, int> Orders { get => _orderRepository; }
        public IRepository<Case, int> Cases { get => _caseRepository; }


        public UnitOfWork(ApplicationDbContext dbContext, IApplicationDbContextFactory dbFactory)
        {
            _userRepository = new(dbFactory);
            _specialistRepository = new(dbContext);
            _clientRepository = new(dbContext);
            _personRepository = new(dbFactory);
            _legalRepository = new(dbFactory);
            _orderRepository = new(dbFactory);
            _caseRepository = new(dbContext, dbFactory);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
