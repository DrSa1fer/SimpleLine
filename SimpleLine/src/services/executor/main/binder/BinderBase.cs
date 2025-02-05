using simpleline.models.options;
using simpleline.services.executor.main.binder.exceptions;

namespace simpleline.services.executor.main.binder;

internal abstract class BinderBase {
    public void Bind(IEnumerable<Option> options, DataInput dataInput) {
        try {
            OnBind(options, dataInput);
        }
        catch (Exception e) {
            throw new BindException(e);
        }
    }

    protected abstract void OnBind(IEnumerable<Option> options, DataInput dataInput);
}