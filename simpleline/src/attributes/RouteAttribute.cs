using simpleline.workers.registrar;
using simpleline.workers.router;

namespace simpleline.attributes;

[AttributeUsage(AttributeTargets.Class)]
public class RouteAttribute(string route) : Attribute,
    IRoute, IRegistered
{
    public string Route { get; } = route;
}