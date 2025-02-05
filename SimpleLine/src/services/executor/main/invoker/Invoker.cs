using simpleline.models.commands;
using simpleline.services.executor.main.binder;
using simpleline.services.executor.main.complier;

namespace simpleline.services.executor.main.invoker;

internal class Invoker(BinderBase binder, ComplierBase complier) : InvokerBase {
    protected override string OnInvoke(Command command, DataInput dataInput) {
        var action = command.Actions.First();

        binder.Bind(command.Options, dataInput);
        binder.Bind(action.Options, dataInput);
        
        if (dataInput.Any()) {
            throw new Exception("Some values not used: " + string.Join(", ", dataInput));
        }
        
        complier.Compliant(command.Options);
        complier.Compliant(action.Options);
        
        var ps = action.Options.Select(x => x.Get()).ToArray();
        return action.Invoke(ps)?.ToString() ?? string.Empty;
    }
}