using simpleline.services.executor.main.binder.actionOptions.arguments;
using simpleline.services.executor.main.binder.commandOptions.arguments;
using simpleline.services.registrar;

namespace simpleline.attributes;

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Parameter)]
public class ArgumentAttribute(int position) : Attribute, IRegistered,
    IActionArgumentAttribute,
    ICommandArgumentAttribute
{
    public int Position => position;
}