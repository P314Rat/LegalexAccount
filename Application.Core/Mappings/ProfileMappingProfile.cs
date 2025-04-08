using Application.Core.DTO;
using AutoMapper;
using Domain.Core.UserAggregate;


namespace Application.Core.Mappings
{
    public class ProfileMappingProfile : Profile
    {
        public ProfileMappingProfile()
        {
            CreateMap<ProfileDTO, Specialist>().ReverseMap();
            CreateMap<ProfileDTO, Legal>().ReverseMap();
            CreateMap<ProfileDTO, Person>().ReverseMap();
        }
    }
}
