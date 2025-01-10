using simpleline.models.commands;
using simpleline.services.executor.exceptions;
using simpleline.services.executor.main.binder;

namespace simpleline.services.executor;

internal abstract class ExecutorBase {
    public void Execute(Command command, Input input) {
        try {
            OnExecute(command, new Data(input));
        }
        catch (Exception e) {
            throw new ExecutorException(e);
        }
    }

    protected abstract void OnExecute(Command command, Data data);
}