using LegalexAccount.DAL.Models.CaseAggregate;

namespace LegalexAccount.DAL.Models.UserAggregate
{
    public interface IUserRepository<out T>
    {
        T GetById(string id);
        T GetByEmail(string email);
        IEnumerable<T> GetAll();
        bool IsExists(string email);
    }
}
