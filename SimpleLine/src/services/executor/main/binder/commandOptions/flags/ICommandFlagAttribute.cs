using simpleline.models.options.commands;

namespace simpleline.services.executor.main.binder.commandOptions.flags;

internal interface ICommandFlagAttribute : ICommandOptionAttribute {
    ICollection<string> Keys { get; }
}