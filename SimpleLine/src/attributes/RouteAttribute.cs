using simpleline.services.executor.help.helper;
using simpleline.services.router;

namespace simpleline.attributes;

[AttributeUsage(AttributeTargets.Class)]
public class RouteAttribute(string route) : Attribute,
    IRoute, IHelpRoute {
    public string Route { get; } = route;
}