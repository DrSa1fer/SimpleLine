using simpleline.workers.router;

namespace simpleline.attributes;

[AttributeUsage(AttributeTargets.Assembly)]
public class RoutePrefixAttribute(string route) : Attribute,
    IRoutePrefix
{
    public IReadOnlyList<string> Route { get; } = default;
}