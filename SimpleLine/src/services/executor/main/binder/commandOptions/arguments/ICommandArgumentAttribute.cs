using simpleline.models.options.commands;

namespace simpleline.services.executor.main.binder.commandOptions.arguments;

internal interface ICommandArgumentAttribute : ICommandOptionAttribute {
    int Position { get; }
    int Arity { get; }
}