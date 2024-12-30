using simpleline.models;

namespace simpleline.helpers;

public static class AttributeHelper
{
    public static T? GetAttribute<T>(this IEnumerable<IAttribute> enumerable)
    {
        return (T?)enumerable
            .FirstOrDefault(x => x is T);
    }
}