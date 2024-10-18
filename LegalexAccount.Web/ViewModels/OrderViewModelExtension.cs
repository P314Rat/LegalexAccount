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
                Service = model.Service,
                Name = model.Name,
                Contact = model.Contact,
                Description = model.Description
            };

            return viewModel;
        }
    }
}
