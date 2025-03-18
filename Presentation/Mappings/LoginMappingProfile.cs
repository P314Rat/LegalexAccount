using Application.Core.DTO.LoginObject;
using AutoMapper;
using Presentation.ViewModels;


namespace Presentation.Mappings
{
    public class LoginMappingProfile : Profile
    {
        public LoginMappingProfile()
        {
            CreateMap<LoginViewModel, LoginDTO>();
        }
    }
}
