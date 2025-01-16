using simpleline.models.options;

namespace simpleline.services.executor.main.validator.handlers;

internal abstract class Handler<T> : Handler where T : IOptionAttribute  {
    public override bool Is(IOptionAttribute attribute) {
        return attribute is T;
    }

    public sealed override bool Handle(IOptionAttribute attribute, object? value) {
        return OnHandle((T)attribute, value);
    }

    protected abstract bool OnHandle(T attribute, object? value);
}