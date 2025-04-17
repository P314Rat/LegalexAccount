using Application.Core.DTO;
using AutoMapper;
using Presentation.ViewModels;


namespace Presentation.Mappings
{
    public class OrderMappingProfile : Profile
    {
        public OrderMappingProfile()
        {
            CreateMap<OrderViewModel, OrderDTO>().ReverseMap();
        }
    }
}
