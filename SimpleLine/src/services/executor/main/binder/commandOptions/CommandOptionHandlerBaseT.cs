using simpleline.models.options.commands;

namespace simpleline.services.executor.main.binder.commandOptions;

internal abstract class CommandOptionHandlerBase<T>()
    : CommandOptionHandlerBase(typeof(T)) where T : ICommandOptionAttribute {
    public override object? Handle(ICommandOptionAttribute attribute, Type valueType, Data data) {
        return OnHandle((T)attribute, valueType, data);
    }

    protected abstract object? OnHandle(T attribute, Type valueType, Data data);
}