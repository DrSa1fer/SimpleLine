using simpleline.models.options.commands;

namespace simpleline.services.binder.commandOptions.flags;

internal interface ICommandFlagAttribute : ICommandOptionAttribute
{
    public IEnumerable<string> Keys { get; }
}