using simpleline.services.executor.main.invoker;
using Microsoft.Extensions.DependencyInjection;

namespace simpleline.services.executor.main;

internal class Main : Case
{
    public override bool Is(Context context)
    {
        return true;
    }

    public override void Invoke(Context context)
    {
        var invoker = context
            .Provider
            .GetService<InvokerBase>();

        ArgumentNullException.ThrowIfNull(invoker);

        invoker.Invoke(context.Command, context.Data);
    }
}