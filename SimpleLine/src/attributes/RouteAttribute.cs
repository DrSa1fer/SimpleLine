using IHRouteAttribute = simpleline.services.executor.help.helper.IRouteAttribute;
using IRRouteAttribute = simpleline.services.router.IRouteAttribute;

namespace simpleline.attributes;

[AttributeUsage(AttributeTargets.Class)]
public class RouteAttribute(string route) : CommandAttribute, IRRouteAttribute, IHRouteAttribute {
    public string Route { get; } = route;
}