using Application.Core.DTO;
using AutoMapper;
using Domain.Core.UserAggregate;


namespace Application.Core.Mappings
{
    public class ProfileMappingProfile : Profile
    {
        public ProfileMappingProfile()
        {
            CreateMap<ProfileDTO, User>().ReverseMap();
        }
    }
}
