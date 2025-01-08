using simpleline.services.registrar;
using simpleline.services.router;

namespace simpleline.attributes;

[AttributeUsage(AttributeTargets.Class)]
public class RouteAttribute(string route) : Attribute,
    IRoute, IRegistered {
    public IReadOnlyList<string> Route { get; } = default;
}