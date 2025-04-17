using Application.Core.DTO;
using AutoMapper;
using Domain.Core.CaseAggregate;


namespace Application.Core.Mappings
{
    public class CaseMappingProfile : Profile
    {
        public CaseMappingProfile()
        {
            CreateMap<CaseDTO, Case>().ReverseMap();
        }
    }
}
