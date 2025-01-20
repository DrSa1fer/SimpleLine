using Microsoft.Extensions.DependencyInjection;
using simpleline.configs;
using simpleline.external.writers;
using simpleline.models.commands;
using simpleline.services.executor.help.helper;
using simpleline.services.executor.main.binder;
using simpleline.services.executor.main.invoker;
using Console = simpleline.external.Console;

namespace simpleline.services.executor;

internal class Executor(IServiceProvider provider) : ExecutorBase {
    protected override void OnExecute(Command command, Data data) {
        var sf = provider.GetRequiredService<FlagConfig>();
        
        if (data.ContainsAny(sf.HelpKeys)) {
            var helper = provider.GetRequiredService<HelperBase>();
            var writer = provider.GetRequiredService<HelpWriter>();
            var output = helper.Help(command);
            
            // writer
        }
        else {
            var invoker = provider.GetRequiredService<InvokerBase>();
            var writer = provider.GetRequiredService<MainWriter>();
            var output = invoker.Invoke(command, data);
            
            // writer
        }
    }
}