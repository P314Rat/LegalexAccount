using LegalexAccount.DAL.Models.CaseAggregate;

namespace LegalexAccount.DAL.Models.UserAggregate
{
    public interface IClientRepository
    {
        void Create(Client item);
        Client GetById(string id);
        IEnumerable<Client> GetAll();
        void Delete(Client item);
        void DeleteById(string id);
        void DeleteAll();
        void Update(Client item);
    }
}
