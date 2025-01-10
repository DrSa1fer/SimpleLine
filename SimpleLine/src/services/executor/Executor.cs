using Microsoft.Extensions.DependencyInjection;
using simpleline.configs;
using simpleline.models.commands;
using simpleline.services.executor.help.helper;
using simpleline.services.executor.main.binder;
using simpleline.services.executor.main.invoker;
using simpleline.services.executor.quit;

namespace simpleline.services.executor;

internal class Executor(IServiceProvider provider) : ExecutorBase {
    protected override void OnExecute(Command command, Data data) {
        var invoker = provider.GetRequiredService<InvokerBase>();
        var helper = provider.GetRequiredService<HelperBase>();
        var hk = provider.GetRequiredService<HelpKeyConfig>();

        //provider.GetRequiredService<AbouterBase>().About();
        // quit.Fail();

        if (data.ContainsAny(hk.HelpKeys)) {
            helper.Help(command);
            // Quit.Ok();
            return; //Unreachable. 'Quit.Ok()' stop a program 
        }

        invoker.Invoke(command, data);
    }
}