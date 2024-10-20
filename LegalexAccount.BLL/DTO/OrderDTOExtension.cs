﻿using LegalexAccount.DAL.Models.OrderAggregate;


namespace LegalexAccount.BLL.DTO
{
    internal static class OrderDTOExtension
    {
        internal static Order ToOrder(this OrderDTO model)
        {
            var order = new Order
            {
                CreatedAt = model.CreatedAt,
                ClientType = model.ClientType,
                Service = model.Service,
                Name = model.Name,
                Contact = model.Contact,
                Description = model.Description
            };

            return order;
        }

        internal static OrderDTO ToDTO(this Order model)
        {
            var orderDTO = new OrderDTO
            {
                Id = model.Id,
                CreatedAt = model.CreatedAt,
                ClientType = model.ClientType,
                Service = model.Service,
                Name = model.Name,
                Contact = model.Contact,
                Description = model.Description
            };

            return orderDTO;
        }
    }
}
