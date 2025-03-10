using System.Linq;
using System.Text.Json;

namespace CleanRobust.Infrastructure.Common;

public static class Extensions
{
    public static bool IsDefault<T>(this T value) =>
        Equals(value, default(T));

    public static string GetGenericTypeName(this object @object)
    {
        var type = @object.GetType();

        if (!type.IsGenericType)
            return type.Name;

        var genericTypes = string.Join(",", type.GetGenericArguments().Select(t => t.Name).ToArray());

        return $"{type.Name[..type.Name.IndexOf('`')]}<{genericTypes}>";
    }

    public static T FromJson<T>(this string value) => value != null ? JsonSerializer.Deserialize<T>(value) : default;

    public static string ToJson<T>(this T value) => !value.IsDefault() ? JsonSerializer.Serialize(value) : default;

}