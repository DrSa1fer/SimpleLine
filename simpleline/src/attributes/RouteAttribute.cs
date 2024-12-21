using simpleline.registrars;
using simpleline.services.routing;

namespace simpleline.attributes;

[AttributeUsage(AttributeTargets.Class)]
public class RouteAttribute(string route) : Attribute,
    IRouted, IRegistered
{
    public IEnumerable<string> Route { get; }
}