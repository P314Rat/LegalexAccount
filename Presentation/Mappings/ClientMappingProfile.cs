using Application.Core.DTO.UserObject;
using AutoMapper;
using Presentation.ViewModels;


namespace Presentation.Mappings
{
    public class ClientMappingProfile : Profile
    {
        public ClientMappingProfile()
        {
            CreateMap<ClientProfileViewModel, ClientDTO>();
        }
    }
}
