using simpleline.models.options.actions;
using simpleline.services.binder.exceptions;

namespace simpleline.services.binder;

internal abstract class ActionOptionBinderBase
{
    public void Bind(IEnumerable<ActionOption> options, Data data)
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
    
    protected abstract void OnBind(IEnumerable<ActionOption> options, Data data);
}