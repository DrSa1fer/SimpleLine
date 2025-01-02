using simpleline.models.options.commands;
using simpleline.services.binder.exceptions;

namespace simpleline.services.binder;

internal abstract class CommandOptionBinderBase
{
    public void Bind(IEnumerable<CommandOption> options, Data data)
    {
        try
        {
            OnBind(options, data);
        }
        catch (Exception e)
        {
            throw new BindException(e);
        }
    }
    
    protected abstract void OnBind(IEnumerable<CommandOption> options, Data data);
}