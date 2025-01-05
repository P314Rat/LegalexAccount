using System.ComponentModel.DataAnnotations;


namespace LegalexAccount.Web.ViewModels
{
    public class ProfileVClientViewModeliewModel
    {
        [Required(ErrorMessage = "Выберите заказчика.")]
        public string SelectedProfile { get; set; }
        public List<ProfileViewModel> Profiles { get; set; }
    }
}
