using simpleline.models.commands;
using simpleline.services.executor.exceptions;

namespace simpleline.services.executor;

internal abstract class ExecutorBase {
    public void Execute(Command command, ref IEnumerable<Symbol> input) {
        try {
            OnExecute(command, (DataInput)(input = new DataInput(input)));
        }
        catch (Exception e) {
            throw new ExecutorException(e);
        }
    }

    protected abstract void OnExecute(Command command, DataInput dataInput);
}