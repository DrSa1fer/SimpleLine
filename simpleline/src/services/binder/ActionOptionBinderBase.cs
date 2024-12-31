using simpleline.models.options.actions;

namespace simpleline.services.binder;

internal abstract class ActionOptionBinderBase
{
    public abstract void Bind(IEnumerable<ActionOption> options, InputData data);
}