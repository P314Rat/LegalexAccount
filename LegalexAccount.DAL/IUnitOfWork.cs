using LegalexAccount.DAL.Models.OrderAggregate;
using LegalexAccount.DAL.Models.CaseAggregate;
using LegalexAccount.DAL.Models.UserAggregate;
using LegalexAccount.DAL.Repositories.Contracts;


namespace LegalexAccount.DAL
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        IRepository<Specialist, Guid> Specialists { get; }
        IRepository<Client, Guid> Clients { get; }
        IRepository<Person, Guid> Individuals { get; }
        IRepository<Legal, Guid> LegalEntities { get; }
        IRepository<Order, int> Orders { get; }
        IRepository<Case, int> Cases { get; }
    }
}
