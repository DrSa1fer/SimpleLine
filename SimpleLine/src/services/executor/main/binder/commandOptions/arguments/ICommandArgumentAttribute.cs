using simpleline.models.options.commands;

namespace simpleline.services.executor.main.binder.commandOptions.arguments;

internal interface ICommandArgumentAttribute : ICommandOptionAttribute {
    public int Position { get; }
}