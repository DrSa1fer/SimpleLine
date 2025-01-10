using simpleline.services.executor.main.typizer.exceptions;
using simpleline.services.executor.main.binder.exceptions;
using simpleline.models.options.actions;

namespace simpleline.services.executor.main.binder;

internal abstract class ActionOptionBinderBase {
    public void Bind(IEnumerable<ActionOption> options, Data data) {
        try {
            OnBind(options, data);
        }
        catch (Exception e) {
            throw new BindException(e);
        }
    }

    protected abstract void OnBind(IEnumerable<ActionOption> options, Data data);
}