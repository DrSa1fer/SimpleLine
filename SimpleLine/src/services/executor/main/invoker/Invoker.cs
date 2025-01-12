using simpleline.models.commands;
using simpleline.services.executor.main.binder;

namespace simpleline.services.executor.main.invoker;

internal class Invoker(
    OptionBinderBase optBinder
) : InvokerBase {
    protected override object? OnInvoke(Command command, Data data) {
        var action = command.Actions.First();

        var commandOptions = command.Options;
        var actionOptions = action.Options;

        optBinder.Bind(commandOptions, data);
        optBinder.Bind(actionOptions, data);

        data.Ensure();

        return action.Invoke();
    }
}