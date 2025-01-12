using simpleline.models.options;

namespace simpleline.services.executor.main.binder.options;

internal abstract class OptionHandlerBase(Type handleType) {
    public bool Is(IOptionAttribute attribute) {
        return attribute.GetType().IsAssignableTo(handleType);
    }

    public abstract object? Handle(IOptionAttribute attribute, Type valueType, Data data);
}