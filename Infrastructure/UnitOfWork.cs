using Domain.Core.AccountAggregate;
using Domain.Core.CaseAggregate;
using Domain.Core.ChatAggregate;
using Domain.Core.OrderAggregate;
using Domain.Core.UserAggregate;
using Infrastructure.Repositories.AccountAggregate;
using Infrastructure.Repositories.CaseAggregate;
using Infrastructure.Repositories.ChatAggregate;
using Infrastructure.Repositories.Contracts;
using Infrastructure.Repositories.OrderAggregate;
using Infrastructure.Repositories.UserAggregate;


namespace Infrastructure
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly UserRepository _userRepository;
        private readonly ClientRepository _clientRepository;
        private readonly SpecialistRepository _specialistRepository;
        private readonly LegalRepository _legalRepository;
        private readonly PersonRepository _personRepository;
        private readonly OrderRepository _orderRepository;
        private readonly CaseRepository _caseRepository;
        private readonly ChatRepository _chatRepository;
        private readonly MessageRepository _messageRepository;
        private readonly PasswordResetTokenRepository _passwordResetTokenRepository;

        public IUserRepository<User, Guid> Users { get => _userRepository; }
        public IUserRepository<Specialist, Guid> Specialists { get => _specialistRepository; }
        public IUserRepository<Client, Guid> Clients { get => _clientRepository; }
        public IUserRepository<Person, Guid> Individuals { get => _personRepository; }
        public IUserRepository<Legal, Guid> LegalEntities { get => _legalRepository; }
        public IRepository<Order, int> Orders { get => _orderRepository; }
        public IRepository<Case, int> Cases { get => _caseRepository; }
        public IRepository<Chat, Guid> Chats { get => _chatRepository; }
        public IRepository<PasswordResetToken, int> PasswordResetTokens { get => _passwordResetTokenRepository; }
        public IRepository<Message, Guid> Messages { get => _messageRepository; }

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _userRepository = new(dbContext);
            _specialistRepository = new(dbContext);
            _clientRepository = new(dbContext);
            _personRepository = new(dbContext);
            _legalRepository = new(dbContext);
            _orderRepository = new(dbContext);
            _caseRepository = new(dbContext);
            _chatRepository = new(dbContext);
            _messageRepository = new(dbContext);
            _passwordResetTokenRepository = new(dbContext);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
