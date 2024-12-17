using simpleline.models.commands;
using simpleline.services.registration;

namespace simpleline.attributes;

[AttributeUsage(AttributeTargets.Class)]
public class RouteAttribute(string route) : Attribute, ICommandAttribute, IRegistered 
{
}