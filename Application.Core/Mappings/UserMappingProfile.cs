using Application.Core.DTO.UserObject;
using AutoMapper;
using Domain.Core.UserAggregate;


namespace Application.Core.Mappings
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UserDTO>()
                .Include<Client, ClientDTO>()
                .Include<Specialist, SpecialistDTO>();

            CreateMap<Client, ClientDTO>()
                .Include<Legal, LegalDTO>()
                .Include<Person, PersonDTO>();

            CreateMap<Specialist, SpecialistDTO>().ReverseMap();
            CreateMap<Legal, LegalDTO>().ReverseMap();
            CreateMap<Person, PersonDTO>().ReverseMap();
        }
    }
}
