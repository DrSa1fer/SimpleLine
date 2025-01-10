using simpleline.models.options.commands;

namespace simpleline.services.executor.main.binder.commandOptions.parameters;

internal interface ICommandParameterAttribute : ICommandOptionAttribute {
    ICollection<string> Keys { get; }
    int Arity { get; }
}