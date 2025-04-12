using Application.Core.DTO;
using AutoMapper;
using Presentation.ViewModels;
using Utilities.Types;


namespace Presentation.Mappings
{
    public class ProfileMappingProfile : Profile
    {
        public ProfileMappingProfile()
        {
            CreateMap<ProfileDTO, ClientViewModel>()
                .ForMember(dst => dst.Type,
                    opt => opt
                    .MapFrom(src =>
                        !string.IsNullOrWhiteSpace(src.OrganizationName)
                            ? ClientType.Legal
                            : ClientType.Person))
                .ForMember(dst => dst.Client,
                        opt => opt
                        .MapFrom(src => $"{src.FirstName} {src.LastName}")
                        )
                .ReverseMap();
            CreateMap<ProfileDTO, SpecialistViewModel>()
                .ForMember(dst => dst.Type,
                    opt => opt.MapFrom(src => src.Role))
                .ForMember(dst => dst.Employee,
                        opt => opt
                        .MapFrom(src => $"{src.FirstName} {src.LastName}")
                        )
                .ReverseMap();
            CreateMap<EditProfileViewModel, ProfileDTO>().ReverseMap()
                .ForAllMembers(opt => opt.NullSubstitute(string.Empty));
        }
    }
}
