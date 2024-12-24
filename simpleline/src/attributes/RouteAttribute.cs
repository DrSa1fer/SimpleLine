using simpleline.services.registrar;
using simpleline.services.router;

namespace simpleline.attributes;

[AttributeUsage(AttributeTargets.Class)]
public class RouteAttribute(string route) : Attribute,
    IRouted, IRegisteredAttribute
{
    public IReadOnlyList<string> Route { get; } = route.Split(' ', StringSplitOptions.RemoveEmptyEntries);
}