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
                CreatedAt = model.CreatedAt,
                ClientType = model.ClientType,
                ServiceType = model.ServiceType,
                Name = model.Name,
                Contact = model.Contact,
                Description = model.Description
            };

            return viewModel;
        }

        internal static OrderDTO ToDTO(this OrderViewModel model)
        {
            var viewModel = new OrderDTO
            {
                Id = model.Id,
                CreatedAt = model.CreatedAt,
                ClientType = model.ClientType,
                ServiceType = model.ServiceType,
                Name = model.Name,
                Contact = model.Contact,
                Description = model.Description
            };

            return viewModel;
        }
    }
}
