using simpleline.models.commands;
using simpleline.services.binder;

namespace simpleline.services.invoker;

internal class Invoker(
    CommandOptionBinderBase comOptBinder,
    ActionOptionBinderBase actOptBinder
) : InvokerBase
{
    public override object? Invoke(Command command, InputData inputData)
    {
        var action = command.Actions.First();

        var commandOptionCollection = command.Options;
        var actionOptionCollection = action.Options;

        comOptBinder.Bind(commandOptionCollection, inputData);
        actOptBinder.Bind(actionOptionCollection, inputData);

        return action.Invoke();
    }
}