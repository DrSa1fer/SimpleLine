using simpleline.models.options;

namespace simpleline.services.executor.main.binder.handlers;

internal abstract class Handler<T> : Handler where T : IOptionAttribute  {
    public override bool Is(IOptionAttribute attribute) {
        return attribute is T;
    }

    public sealed override void Handle(IOptionAttribute attribute, Option option, Data data) {
        OnHandle((T)attribute, option, data);
    }

    protected abstract void OnHandle(T attribute, Option option, Data data);
}