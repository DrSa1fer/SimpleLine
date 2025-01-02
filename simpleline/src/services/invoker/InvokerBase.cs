using simpleline.models.commands;
using simpleline.workers;

namespace simpleline.services.invoker;

internal abstract class InvokerBase
{
    public abstract void Invoke(Command command, Data data);
}