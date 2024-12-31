using simpleline.models.commands;
using simpleline.services.binder;

namespace simpleline.services.invoker;

internal abstract class InvokerBase
{
    public abstract object? Invoke(Command command, InputData inputData);
}