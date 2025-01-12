using simpleline.models.options;

namespace simpleline.services.executor.main.binder.options;

internal abstract class OptionHandlerBase<T>()
    : OptionHandlerBase(typeof(T)) where T : IOptionAttribute {
    public sealed override object? Handle(IOptionAttribute attribute, Type valueType, Data data) {
        return OnHandle((T)attribute, valueType, data);
    }

    protected abstract object? OnHandle(T attribute, Type valueType, Data data);
}