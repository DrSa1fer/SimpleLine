using simpleline.services.binder;
using simpleline.services.invoker;
using simpleline.services.typizer;

namespace simpleline.services;

public class Pipeline
{
    public void Run(Context context)
    {
        var cOptBinder = new CommandOptionBinder();
        var aOptBinder = new ActionOptionBinder();
        var invoker = new ActionInvoker();
        var typizer = new Typizer();
        
        throw new NotImplementedException();
    }
}