using simpleline.models.commands;
using simpleline.services.executor.main.binder;

namespace simpleline.services.executor.main.invoker;

internal class Invoker(
    CommandOptionBinderBase comOptBinder,
    ActionOptionBinderBase actOptBinder
) : InvokerBase {
    protected override object? OnInvoke(Command command, Data data) {
        var action = command.Actions.First();

        var commandOptionCollection = command.Options;
        var actionOptionCollection = action.Options;

        comOptBinder.Bind(commandOptionCollection, data);
        actOptBinder.Bind(actionOptionCollection, data);

        data.Ensure();

        return action.Invoke();
    }
}