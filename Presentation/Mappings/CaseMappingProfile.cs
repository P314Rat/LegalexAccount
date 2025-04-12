using Application.Core.DTO;
using AutoMapper;
using Presentation.ViewModels;


namespace Presentation.Mappings
{
    public class CaseMappingProfile : Profile
    {
        public CaseMappingProfile()
        {
            CreateMap<CaseDTO, CaseViewModel>()
                .ForMember(
                    dst => dst.Customer,
                    opt => opt.MapFrom(src => $"{src.Customer.FirstName} {src.Customer.LastName}")
                    )
                .ReverseMap();
        }
    }
}
