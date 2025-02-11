using System.ComponentModel.DataAnnotations;


namespace LegalexAccount.Web.ViewModels
{
    public class CreateCaseViewModel
    {
        public DateTime StartDate { get; set; } = DateTime.Now;
        public int? EstimatedDaysToEnd { get; set; } = null;
        [Required(ErrorMessage = "Это необходимое поле")]
        public string Customer { get; set; }
        public List<string> Assignees { get; set; }
        [Required(ErrorMessage = "Это необходимое поле")]
        public string Description { get; set; } = string.Empty;
    }
}
