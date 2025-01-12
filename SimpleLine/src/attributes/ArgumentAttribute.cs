using simpleline.services.executor.main.binder.options.arguments;
using simpleline.services.registrar;

namespace simpleline.attributes;

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Parameter)]
public class ArgumentAttribute(int position, int arity = 1) : Attribute, IRegistered,
    IArgumentAttribute {
    public int Position => position;
    public int Arity => arity;
}