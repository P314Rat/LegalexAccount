using System.ComponentModel.DataAnnotations;
using System.Reflection;


namespace Utilities.Extensions
{
    public static class EnumExtension
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
