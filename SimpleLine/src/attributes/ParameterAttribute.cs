using simpleline.services.executor.main.binder.options.parameters;
using simpleline.services.registrar;

namespace simpleline.attributes;

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Parameter)]
public class ParameterAttribute(string[] aliases, int arity = 1) : Attribute, IRegistered,
    IParameterAttribute {
    public ICollection<string> Keys => aliases;
    public int Arity => arity;
}