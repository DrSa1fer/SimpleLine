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
        var console = provider.GetRequiredService<Console>();
        var result = default(string);
        
        var hk = provider.GetRequiredService<HelpKeyConfig>();
        if (data.ContainsAny(hk.HelpKeys)) {
            var helper = provider.GetRequiredService<HelperBase>();
            result = helper.Help(command);
        }
        else {
            var invoker = provider.GetRequiredService<InvokerBase>();
            result = invoker.Invoke(command, data)?.ToString();
        }
        
        if (result is null) {
            return;
        }
            
        console.Out.WriteLine(result);
    }
}