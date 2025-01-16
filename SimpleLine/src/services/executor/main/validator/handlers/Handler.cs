using simpleline.models.options;

namespace simpleline.services.executor.main.validator.handlers;

internal abstract class Handler {
    public abstract bool Is(IOptionAttribute attribute);
    public abstract bool Handle(IOptionAttribute attribute, object? value);
}