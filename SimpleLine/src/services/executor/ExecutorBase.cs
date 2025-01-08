using simpleline.models.commands;

namespace simpleline.services.executor;

internal abstract class ExecutorBase {
    public void Execute(Command command, Input input) {
        try {
            OnExecute(command, new Data([]));
        }
        catch (Exception e) {
            Console.WriteLine(e);
            throw;
        }
    }

    protected abstract void OnExecute(Command command, Data data);
}