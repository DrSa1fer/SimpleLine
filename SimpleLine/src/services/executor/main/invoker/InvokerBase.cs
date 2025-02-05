using simpleline.models.commands;
using simpleline.services.executor.main.invoker.exceptions;

namespace simpleline.services.executor.main.invoker;

internal abstract class InvokerBase {
    public string Invoke(Command command, DataInput dataInput) {
        try {
            return OnInvoke(command, dataInput);
        }
        catch (Exception e) {
            throw new InvokeException(e);
        }
    }

    protected abstract string OnInvoke(Command command, DataInput dataInput);
}