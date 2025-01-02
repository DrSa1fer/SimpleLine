using simpleline.models.commands;
using simpleline.services.binder;
using simpleline.workers;

namespace simpleline.services.invoker;

internal class Invoker(
    CommandOptionBinderBase comOptBinder,
    ActionOptionBinderBase actOptBinder
) : InvokerBase
{
    public override void Invoke(Command command, Data data)
    {
        var action = command.Actions.First();
        
        var commandOptionCollection = command.Options;
        var actionOptionCollection = action.Options;
        
        comOptBinder.Bind(commandOptionCollection, data);
        actOptBinder.Bind(actionOptionCollection, data);

        if (!data.Ensure())
        {
            throw new Exception("unused arguments");
        }
        
        action.Invoke();
    }
}