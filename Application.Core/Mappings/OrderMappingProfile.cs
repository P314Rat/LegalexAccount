using Application.Core.DTO;
using AutoMapper;
using Domain.Core.OrderAggregate;


namespace Application.Core.Mappings
{
    public class OrderMappingProfile : Profile
    {
        public OrderMappingProfile()
        {
            CreateMap<OrderDTO, Order>().ReverseMap();
        }
    }
}
