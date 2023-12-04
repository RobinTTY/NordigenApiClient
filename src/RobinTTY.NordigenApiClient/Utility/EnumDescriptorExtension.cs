using System.ComponentModel;
#if NET6_0_OR_GREATER
using System.Diagnostics.CodeAnalysis;
#endif

namespace RobinTTY.NordigenApiClient.Utility;

internal static class EnumDescriptorExtension
{
    internal static string? GetDescription<T>(this T enumerationValue) where T : struct
    {
        var type = enumerationValue.GetType();
        if (!type.IsEnum)
            throw new ArgumentException("EnumerationValue must be of Enum type", nameof(enumerationValue));

        var memberInfo = type.GetMember(enumerationValue.ToString() ?? string.Empty);
        if (memberInfo is {Length: > 0})
        {
            var attrs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (attrs.Length > 0)
                return ((DescriptionAttribute) attrs[0]).Description;
        }

        return enumerationValue.ToString();
    }

#if NET6_0_OR_GREATER
    internal static T
        StringToEnumValue<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicFields)] T>(
            string? description) where T : struct
#else
    internal static T StringToEnumValue<T>(string? description) where T : struct
#endif
    {
        var fieldInfos = typeof(T).GetFields();

        foreach (var fieldInfo in fieldInfos)
        {
            var attributes =
                (DescriptionAttribute[]) fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes.Length > 0 && attributes[0].Description == description)
                return (T) Enum.Parse(typeof(T), fieldInfo.Name);
        }

        return default!;
    }
}
