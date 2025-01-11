using simpleline.models.options.actions;

namespace simpleline.services.executor.main.binder.actionOptions;

internal abstract class ActionOptionHandlerBase (Type handleType) {
    public bool Is(IActionOptionAttribute attribute) {
        return attribute.GetType().IsAssignableTo(handleType);
    }
    public abstract object? Handle(IActionOptionAttribute attribute, Type valueType, Data data);
}