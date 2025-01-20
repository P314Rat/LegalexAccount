using System.ComponentModel.DataAnnotations;


namespace LegalexAccount.Utility.Types
{
    public enum ServiceType
    {
        [Display(Name = "Не выбран")]
        NonSelected = 0,
        [Display(Name = "Юридические услуги")]
        Legal = 1,
        [Display(Name = "Антикризисное управление")]
        CrisisManagement = 2,
        [Display(Name = "Медиация")]
        Mediation = 3,
        [Display(Name = "HR услуги")]
        HR = 4,
        [Display(Name = "Услуги кадрового специалиста")]
        HRSupport = 5,
        [Display(Name = "Охрана труда")]
        OccupationalSafetyAndHealth = 6,
        [Display(Name = "Защита персональных данных")]
        ProtectionOfPersonalInformation = 7,
        [Display(Name = "Услуги экономиста")]
        Finance = 8
    }
}
