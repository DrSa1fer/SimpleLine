using Microsoft.Extensions.DependencyInjection;
using simpleline.configs;
using simpleline.models.commands;
using simpleline.services.executor.help.helper;
using simpleline.services.executor.main.binder;
using simpleline.services.executor.main.invoker;
using Console = simpleline.exmodels.Console;

namespace simpleline.services.executor;

internal class Executor(IServiceProvider provider) : ExecutorBase {
    protected override void OnExecute(Command command, Data data) {
        var sf = provider.GetRequiredService<SpecialFlagConfig>();
        var console = provider.GetRequiredService<Console>();
        var output = default(string);
        
        if (data.ContainsAny(sf.HelpKeys)) {
            var helper = provider.GetRequiredService<HelperBase>();
            output = helper.Help(command);
        }
        else {
            var invoker = provider.GetRequiredService<InvokerBase>();
            output = invoker.Invoke(command, data)?.ToString();
        }

        if (output is not null) {
            console.Out.WriteLine(output);
        }
    }
}