using simpleline.models.options.actions;

namespace simpleline.services.executor.main.binder.actionOptions;

internal abstract class ActionOptionHandlerBase {
    public abstract bool Is(IActionOptionAttribute attribute);
    public abstract void Handle(IActionOptionAttribute attribute, ActionOption option, Data data);
}