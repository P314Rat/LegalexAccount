using LegalexAccount.BLL.DTO;


namespace LegalexAccount.Web.ViewModels
{
    internal static class OrderViewModelExtension
    {
        internal static OrderViewModel ToViewModel(this OrderDTO model)
        {
            var viewModel = new OrderViewModel
            {
                Id = model.Id,
                CreatedAt = model.CreatedAt ?? DateTime.Now,
                ClientType = model.ClientType ?? Utility.Types.ClientType.Legal,
                ServiceType = model.ServiceType ?? Utility.Types.ServiceType.Legal,
                Name = model.Name ?? string.Empty,
                Contact = model.Contact ?? string.Empty,
                Description = model.Description ?? string.Empty
            };

            return viewModel;
        }

        internal static OrderDTO ToDTO(this OrderViewModel model)
        {
            var modelDTO = new OrderDTO
            {
                Id = model.Id,
                CreatedAt = model.CreatedAt,
                ClientType = model.ClientType,
                ServiceType = model.ServiceType,
                Name = model.Name,
                Contact = model.Contact,
                Description = model.Description
            };

            return modelDTO;
        }
    }
}
