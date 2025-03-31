using Application.Core.DTO;
using AutoMapper;
using Presentation.ViewModels;


namespace Presentation.Mappings
{
    public class ProfileMappingProfile : Profile
    {
        public ProfileMappingProfile()
        {
            CreateMap<EditProfileViewModel, ProfileDTO>().ReverseMap()
                .ForAllMembers(opt => opt.NullSubstitute(string.Empty));
        }
    }
}
