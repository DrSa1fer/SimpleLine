using simpleline.services.binder.commandOptions.arguments;

namespace simpleline.attributes;

[AttributeUsage(AttributeTargets.Field)]
public class ArgumentAttribute(int position) : Attribute, ICommandArgumentAttribute
{
    public int Position => position;
}