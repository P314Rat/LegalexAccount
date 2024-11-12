using LegalexAccount.DAL.Models.OrderAggregate;


namespace LegalexAccount.BLL.DTO
{
    internal static class OrderDTOExtension
    {
        internal static Order ToModel(this OrderDTO model)
        {
            var resultModel = new Order
            {
                CreatedAt = model.CreatedAt ?? DateTime.Now,
                ClientType = model.ClientType ?? Utility.Types.ClientType.Legal,
                Service = model.ServiceType ?? Utility.Types.ServiceType.NonSelected,
                Name = model.Name ?? string.Empty,
                Contact = model.Contact ?? string.Empty,
                Description = model.Description ?? string.Empty
            };

            return resultModel;
        }

        internal static OrderDTO ToDTO(this Order model)
        {
            var resultModel = new OrderDTO
            {
                Id = model.Id,
                CreatedAt = model.CreatedAt,
                ClientType = model.ClientType,
                ServiceType = model.Service,
                Name = model.Name,
                Contact = model.Contact,
                Description = model.Description
            };

            return resultModel;
        }
    }
}
