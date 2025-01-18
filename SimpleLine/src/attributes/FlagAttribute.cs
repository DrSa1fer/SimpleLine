using simpleline.services.executor.main.binder.handlers.flags;
using simpleline.services.registrar;

namespace simpleline.attributes;

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Parameter)]
public class FlagAttribute(
    string[] aliases
) : Attribute, IRegistered, IFlagAttribute {
    public ICollection<string> Aliases { get; } = aliases;
}