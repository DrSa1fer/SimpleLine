using simpleline.services.executor.main.binder.actionOptions.flags;
using simpleline.services.executor.main.binder.commandOptions.flags;
using simpleline.services.registrar;

namespace simpleline.attributes;

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Parameter)]
public class FlagAttribute(string[] aliases) : Attribute, IRegistered,
    IActionFlagAttribute,
    ICommandFlagAttribute {
    public ICollection<string> Keys { get; } = aliases;
}