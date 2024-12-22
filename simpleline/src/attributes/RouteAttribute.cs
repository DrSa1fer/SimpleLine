using simpleline.registrars;
using simpleline.services.routing;

namespace simpleline.attributes;

[AttributeUsage(AttributeTargets.Class)]
public class RouteAttribute(string route) : Attribute,
    IRouted, IRegistered
{
    public IReadOnlyList<string> Route { get; } = route.Split(' ', StringSplitOptions.RemoveEmptyEntries);
}