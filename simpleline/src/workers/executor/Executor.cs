using simpleline.services;
using simpleline.services.binder.actionOptions;
using simpleline.services.binder.commandOptions;
using simpleline.services.typizer;

namespace simpleline.workers.executor;

internal class Executor
{
    public void Run(Context context)
    {
        var typizer = new Typizer();
        var cOptBinder = new CommandOptionBinder();
        
        var aOptBinder = new ActionOptionBinder(typizer);
        
        // context.Command.

        throw new NotImplementedException();
    }
}