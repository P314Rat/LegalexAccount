using LegalexAccount.BLL.DTO.Case;


namespace LegalexAccount.Web.ViewModels.Case
{
    internal static class CaseViewModelExtension
    {
        internal static CaseViewModel ToViewModel(this CaseDTO model)
        {
            var resultModel = new CaseViewModel
            {
                StartDate = model.StartDate ?? throw new NullReferenceException(),
                EstimatedDaysToEnd = model.EstimatedDaysToEnd,
                CustomerEmail = model.CustomerEmail ?? "N/A",
                AssigneeEmail = model.AssigneeEmail ?? "N/A",
                Description = model.Description ?? string.Empty
            };

            return resultModel;
        }

        internal static CaseDTO ToDTO(this CaseViewModel model)
        {
            var resultModel = new CaseDTO
            {
                StartDate = model.StartDate,
                EstimatedDaysToEnd = model.EstimatedDaysToEnd,
                CustomerEmail = model.CustomerEmail,
                AssigneeEmail = model.AssigneeEmail,
                Description = model.Description
            };

            return resultModel;
        }
    }
}
