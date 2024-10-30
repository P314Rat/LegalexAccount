using LegalexAccount.DAL.Models.UserAggregate;
using System.ComponentModel.DataAnnotations;


namespace LegalexAccount.Web.ViewModels
{
    public class CaseViewModel
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public int? EstimatedDaysToEnd { get; set; } = null;
        [Required(ErrorMessage = "Это необходимое поле")]
        public Client Customer { get; set; }
        public List<Specialist>? Assignee { get; set; } = null;
        [Required(ErrorMessage = "Это необходимое поле")]
        public string Description { get; set; } = string.Empty;
    }
}
