using simpleline.models.options;
using simpleline.models.options.commands;
using simpleline.services.binder.commandOptions.flags;
using simpleline.workers.registrar;

namespace simpleline.attributes;

[AttributeUsage(AttributeTargets.Field)]
public class FlagAttribute(string[] aliases) : Attribute, 
    ICommandFlagAttribute,
    IRegistered
{
    public IEnumerable<string> Keys { get; } = aliases;
}