using simpleline.models.options.actions;

namespace simpleline.services.executor.main.binder.actionOptions;

internal abstract class ActionOptionHandlerBase<T>()
    : ActionOptionHandlerBase(typeof(T)) where T : IActionOptionAttribute {
    public sealed override object? Handle(IActionOptionAttribute attribute, Type valueType, Data data) {
        return OnHandle((T)attribute, valueType, data);
    }

    protected abstract object? OnHandle(T attribute, Type valueType, Data data);
}