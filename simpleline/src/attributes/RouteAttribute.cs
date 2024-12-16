using simpleline.services.registration;

namespace simpleline.attributes;

[AttributeUsage(AttributeTargets.Class)]
public class RouteAttribute(string route) : Attribute, IRegistered
{
    string IRegistered.Route { get; } = route;
}