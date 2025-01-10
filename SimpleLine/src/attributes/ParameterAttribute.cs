using simpleline.services.executor.main.binder.actionOptions.parameters;
using simpleline.services.executor.main.binder.commandOptions.parameters;
using simpleline.services.registrar;

namespace simpleline.attributes;

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Parameter)]
public class ParameterAttribute(string[] aliases, int arity = 1) : Attribute, IRegistered,
    IActionParameterAttribute,
    ICommandParameterAttribute {
    public ICollection<string> Keys => aliases;
    public int Arity => arity;
}