using simpleline.models.commands;
using simpleline.services.executor.main.binder;
using simpleline.services.executor.main.validator;

namespace simpleline.services.executor.main.invoker;

internal class Invoker(BinderBase binder, ValidatorBase validator) : InvokerBase {
    protected override string OnInvoke(Command command, Data data) {
        var action = command.Actions.First();

        binder.Bind(command.Options, data);
        binder.Bind(action.Options, data);
        data.Ensure();
        
        validator.Validate(command.Options);
        validator.Validate(action.Options);

        var args = action.Options.Select(x => x.Get()).ToArray();
        
        return action.Invoke(args)?.ToString() ?? string.Empty;
    }
}