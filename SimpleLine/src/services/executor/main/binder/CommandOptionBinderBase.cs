using simpleline.models.options.commands;
using simpleline.services.executor.main.binder.exceptions;
using simpleline.services.executor.main.typizer.exceptions;

namespace simpleline.services.executor.main.binder;

internal abstract class CommandOptionBinderBase
{
    public void Bind(IEnumerable<CommandOption> options, Data data)
    {
        try
        {
            OnBind(options, data);
        }
        catch (TypizeException)
        {
            throw;
        }
        catch (Exception e)
        {
            throw new BindException(e);
        }
    }

    protected abstract void OnBind(IEnumerable<CommandOption> options, Data data);
}