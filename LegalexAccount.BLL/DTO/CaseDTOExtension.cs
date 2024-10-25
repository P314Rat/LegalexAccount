using LegalexAccount.DAL.Models.CaseAggregate;


namespace LegalexAccount.BLL.DTO
{
    internal static class CaseDTOExtension
    {
        internal static Case ToModel(this CaseDTO model)
        {
            var caseModel = new Case
            {
                StartDate = model.StartDate,
                EstimatedDaysToEnd = model.EstimatedDaysToEnd,
                Assignee = model.Assignee,
                Customer = model.Customer,
                Description = model.Description
            };

            return caseModel;
        }

        internal static CaseDTO ToDTO(this Case model)
        {
            var orderDTO = new CaseDTO
            {
                Id = model.Id,
                StartDate = model.StartDate,
                EstimatedDaysToEnd = model.EstimatedDaysToEnd,
                Assignee = model.Assignee,
                Customer = model.Customer,
                Description = model.Description
            };

            return orderDTO;
        }
    }
}
