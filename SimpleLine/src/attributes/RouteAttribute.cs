using simpleline.services.executor.help.helper;
using simpleline.services.router;

namespace simpleline.attributes;

[AttributeUsage(AttributeTargets.Class)]
public class RouteAttribute(string route) : Attribute,
    IRouteAttribute, IHelpRoute {
    public string Route { get; } = route;
}