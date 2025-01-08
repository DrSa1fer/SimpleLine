using simpleline.models.commands;
using simpleline.services.executor.main.binder.exceptions;
using simpleline.services.executor.main.invoker.exceptions;
using simpleline.services.executor.main.typizer.exceptions;

namespace simpleline.services.executor.main.invoker;

internal abstract class InvokerBase {
    public void Invoke(Command command, Data data) {
        try {
            OnInvoke(command, data);
        }
        catch (BindException) {
            throw;
        }
        catch (TypizeException) {
            throw;
        }
        catch (Exception e) {
            throw new InvokeException(e);
        }
    }

    protected abstract void OnInvoke(Command command, Data data);
}