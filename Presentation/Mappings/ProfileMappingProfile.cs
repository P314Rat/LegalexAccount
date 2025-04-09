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
                .ForMember(dest => dest.Type,
                    opt => opt.MapFrom(src =>
                        !string.IsNullOrWhiteSpace(src.OrganizationName)
                            ? ClientType.Legal
                            : ClientType.Person))
                .ReverseMap();

            CreateMap<EditProfileViewModel, ProfileDTO>().ReverseMap()
                .ForAllMembers(opt => opt.NullSubstitute(string.Empty));
        }
    }
}
