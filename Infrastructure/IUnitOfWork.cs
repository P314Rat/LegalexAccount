using Domain.Core.AccountAggregate;
using Domain.Core.CaseAggregate;
using Domain.Core.ChatAggregate;
using Domain.Core.OrderAggregate;
using Domain.Core.UserAggregate;
using Infrastructure.Repositories.Contracts;


namespace Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository<User, Guid> Users { get; }
        IUserRepository<Client, Guid> Clients { get; }
        IUserRepository<Specialist, Guid> Specialists { get; }
        IUserRepository<Legal, Guid> LegalEntities { get; }
        IUserRepository<Person, Guid> Individuals { get; }
        IRepository<Order, int> Orders { get; }
        IRepository<Case, int> Cases { get; }
        IRepository<Chat, Guid> Chats { get; }
        IRepository<Message, Guid> Messages { get; }
        IRepository<PasswordResetToken, int> PasswordResetTokens { get; }
    }
}
