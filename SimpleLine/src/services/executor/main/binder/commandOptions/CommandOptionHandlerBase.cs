using simpleline.models.options.commands;

namespace simpleline.services.executor.main.binder.commandOptions;

internal abstract class CommandOptionHandlerBase(Type handleType) {
    public bool Is(ICommandOptionAttribute attribute) {
        return attribute.GetType().IsAssignableTo(handleType);
    }
    public abstract object? Handle(ICommandOptionAttribute attribute, Type valueType, Data data);
}