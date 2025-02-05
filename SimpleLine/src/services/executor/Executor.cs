using Microsoft.Extensions.DependencyInjection;
using simpleline.configs;
using simpleline.external.writers;
using simpleline.models.commands;
using simpleline.services.executor.help.helper;
using simpleline.services.executor.main.invoker;

namespace simpleline.services.executor;

internal class Executor(IServiceProvider provider) : ExecutorBase {
    protected override void OnExecute(Command command, DataInput dataInput) {
        var sf = provider.GetRequiredService<FlagConfig>();
        
        if (sf.HelpKeys.Any(dataInput.Contains)) {
            var helper = provider.GetRequiredService<HelperBase>();
            var writer = provider.GetRequiredService<HelpWriter>();
            var output = helper.Help(command);
            
            writer.Write(output);
        }
        else {
            var invoker = provider.GetRequiredService<InvokerBase>();
            var writer = provider.GetRequiredService<MainWriter>();
            var output = invoker.Invoke(command, dataInput);
            
            writer.Write(output);
        }
    }
}