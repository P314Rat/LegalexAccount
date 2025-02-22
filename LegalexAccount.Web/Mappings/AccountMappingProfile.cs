using AutoMapper;
using LegalexAccount.BLL.DTO;
using LegalexAccount.Web.ViewModels.Account;


namespace LegalexAccount.Web.Mappings
{
    public class AccountMappingProfile : Profile
    {
        public AccountMappingProfile()
        {
            CreateMap<LoginViewModel, AccountDTO>();
        }
    }
}
