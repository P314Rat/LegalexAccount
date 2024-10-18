using System.ComponentModel.DataAnnotations;


namespace LegalexAccount.Utility.Types
{
    public enum ServiceType
    {
        [Display(Name = "Не выбран")]
        NonSelected,
        [Display(Name = "Юридические услуги")]
        Legal,
        [Display(Name = "Антикризисное управление")]
        CrisisManagement,
        [Display(Name = "Медиация")]
        Mediation,
        [Display(Name = "HR услуги")]
        HR,
        [Display(Name = "Услуги кадрового специалиста")]
        HRSupport,
        [Display(Name = "Охрана труда")]
        OccupationalSafetyAndHealth,
        [Display(Name = "Защита персональных данных")]
        ProtectionOfPersonalInformation,
        [Display(Name = "Услуги экономиста")]
        Finance
    }
}
