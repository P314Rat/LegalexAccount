using System.ComponentModel.DataAnnotations;
using System.Reflection;


namespace LegalexAccount.Utility.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDisplayName(this Enum value)
        {
            var enumType = value.GetType();
            var memberInfo = enumType.GetMember(value.ToString()).FirstOrDefault();
            var displayName = memberInfo?.GetCustomAttribute<DisplayAttribute>()?.Name ?? value.ToString();

            return displayName;
        }
    }
}
