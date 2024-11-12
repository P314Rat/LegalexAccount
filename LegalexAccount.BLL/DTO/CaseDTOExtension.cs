using LegalexAccount.DAL.Models.CaseAggregate;


namespace LegalexAccount.BLL.DTO
{
    internal static class CaseDTOExtension
    {
        internal static Case ToModel(this CaseDTO model)
        {
            var resultModel = new Case
            {
                StartDate = model.StartDate ?? DateTime.Now,
                EstimatedDaysToEnd = model.EstimatedDaysToEnd,
                Assignee = model.Assignee,
                Customer = model.Customer ?? throw new Exception("Wrong customer"),
                Description = model.Description ?? string.Empty
            };

            return resultModel;
        }

        internal static CaseDTO ToDTO(this Case model)
        {
            var resultModel = new CaseDTO
            {
                Id = model.Id,
                StartDate = model.StartDate,
                EstimatedDaysToEnd = model.EstimatedDaysToEnd,
                Assignee = model.Assignee,
                Customer = model.Customer,
                Description = model.Description
            };

            return resultModel;
        }
    }
}
