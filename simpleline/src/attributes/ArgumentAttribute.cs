using simpleline.services.binder.commandOptions.arguments;
using simpleline.workers.registrar;

namespace simpleline.attributes;

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
public class ArgumentAttribute(int position) : Attribute, 
    ICommandArgumentAttribute,
    IRegistered
{
    public int Position => position;
}