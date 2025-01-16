using simpleline.models.options;

namespace simpleline.services.executor.main.binder.handlers;

internal abstract class Handler {
    public abstract bool Is(IOptionAttribute attribute);
    public abstract void Handle(IOptionAttribute attribute, Option option, Data data);
}