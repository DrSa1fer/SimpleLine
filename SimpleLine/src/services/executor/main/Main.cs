using simpleline.services.executor.main.invoker;
using Microsoft.Extensions.DependencyInjection;
using simpleline.models.commands;

namespace simpleline.services.executor.main;

internal class Main(IServiceProvider provider) : Case
{
    public override bool Is(Data data)
    {
        return true;
    }

    public override void Invoke(Command command, Data data)
    {
        provider
            .GetRequiredService<InvokerBase>()
            .Invoke(command, data);
    }
}