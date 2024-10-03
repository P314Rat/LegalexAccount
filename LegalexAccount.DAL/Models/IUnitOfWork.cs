using LegalexAccount.DAL.Models.OrderAggregate;
using LegalexAccount.DAL.Models.CaseAggregate;
using LegalexAccount.DAL.Models.UserAggregate;


namespace LegalexAccount.DAL.Models
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository<User> Users { get; }
        ISpecialistRepository Specialists { get; }
        IClientRepository Clients { get; }
        IOrderRepository Orders { get; }
        ICaseRepository Cases { get; }


        void SaveChanges();
    }
}
