using LegalexAccount.BLL.DTO.Case;


namespace LegalexAccount.Web.ViewModels
{
    internal static class CaseViewModelExtension
    {
        internal static CaseViewModel ToViewModel(this CaseDTO model)
        {
            throw new NotImplementedException();
        }

        internal static CaseDTO ToDTO(this CaseViewModel model)
        {
            var resultModel = new CaseDTO
            {
                EstimatedDaysToEnd = model.EstimatedDaysToEnd,
                CustomerEmail = model.CustomerEmail,
                AssigneeEmail = model.AssigneeEmail,
                Description = model.Description
            };

            return resultModel;
        }
    }
}
