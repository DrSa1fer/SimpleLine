using simpleline.models.commands;
using simpleline.services.executor.main.binder;
using simpleline.services.executor.main.invoker.exceptions;

namespace simpleline.services.executor.main.invoker;

internal abstract class InvokerBase {
    public object? Invoke(Command command, Data data) {
        try {
            return OnInvoke(command, data);
        }
        catch (Exception e) {
            throw new InvokeException(e);
        }
    }

    protected abstract object? OnInvoke(Command command, Data data);
}