using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;


namespace LegalexAccount.Web.ViewModels.Case
{
    public class CaseViewModel
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now;
        public int? EstimatedDaysToEnd { get; set; } = null;
        [Required(ErrorMessage = "Это необходимое поле")]
        public SelectListItem Customer { get; set; }
        public List<SelectListItem> Assignees { get; set; }
        [Required(ErrorMessage = "Это необходимое поле")]
        public string Description { get; set; } = string.Empty;
    }
}
