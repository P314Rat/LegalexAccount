using System.ComponentModel.DataAnnotations;


namespace LegalexAccount.Web.ViewModels.Case
{
    public class CaseViewModel
    {
        public DateTime StartDate { get; set; }
        public int? EstimatedDaysToEnd { get; set; } = null;
        [Required(ErrorMessage = "Это необходимое поле")]
        public string CustomerEmail { get; set; }
        public string AssigneeEmail { get; set; }
        [Required(ErrorMessage = "Это необходимое поле")]
        public string Description { get; set; } = string.Empty;
    }
}
