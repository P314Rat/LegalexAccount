using LegalexAccount.DAL.Models.OrderAggregate;
using LegalexAccount.DAL.Models.CaseAggregate;
using LegalexAccount.DAL.Models.UserAggregate;


namespace LegalexAccount.DAL.Models
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        IClientRepository Clients { get; }
        ISpecialistRepository Specialists { get; }
        IPersonRepository Individuals { get; }
        ILegalRepository LegalEntities { get; }
        IOrderRepository Orders { get; }
        ICaseRepository Cases { get; }
    }
}
