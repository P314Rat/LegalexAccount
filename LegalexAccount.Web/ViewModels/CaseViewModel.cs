using LegalexAccount.DAL.Models.UserAggregate;
using System.ComponentModel.DataAnnotations;


namespace LegalexAccount.Web.ViewModels
{
    public class CaseViewModel
    {
        public int? EstimatedDaysToEnd { get; set; } = null;
        [Required(ErrorMessage = "Это необходимое поле")]
        public Client Customer { get; set; }
        public Specialist Assignee { get; set; }
        [Required(ErrorMessage = "Это необходимое поле")]
        public string Description { get; set; } = string.Empty;
    }
}
