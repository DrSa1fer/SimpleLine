using simpleline.configs;
using simpleline.models.commands;
using simpleline.services;
using simpleline.services.binder;
using simpleline.services.binder.actionOptions;
using simpleline.services.binder.commandOptions;
using simpleline.services.helper;
using simpleline.services.invoker;
using simpleline.services.typizer;

namespace simpleline.workers.executor;

internal class Executor : ExecutorBase
{
    public override void Execute(Context context)
    {
        var typizer = new Typizer();

        var cOptBinder = new CommandOptionBinder(typizer);
        var aOptBinder = new ActionOptionBinder(typizer);

        var invoker = new Invoker(cOptBinder, aOptBinder);
        
        invoker.Invoke(context.Command, context.Data);
    }
}