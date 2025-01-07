using simpleline.models.options.commands;

namespace simpleline.services.executor.main.binder.commandOptions.flags;

internal interface ICommandFlagAttribute : ICommandOptionAttribute
{
    public IEnumerable<string> Keys { get; }
}