using simpleline.workers.registrar;
using simpleline.workers.router;

namespace simpleline.attributes;

[AttributeUsage(AttributeTargets.Class)]
public class RouteAttribute(string route) : Attribute,
    IRouted, IRegistered
{
    public IReadOnlyList<string> Route { get; } = route.Split(' ', StringSplitOptions.RemoveEmptyEntries);
}