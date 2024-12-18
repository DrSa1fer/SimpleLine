using simpleline.models;
using simpleline.models.commands;
using simpleline.services.execution.options;
using simpleline.services.execution.options.arguments;
using simpleline.services.execution.options.parameters;

namespace simpleline.services.execution;

public class Executor : ExecutorBase
{
    private readonly IEnumerable<OptionHandlerBase> _optionHandlers =
    [
        new ParameterHandler(),
        new ArgumentHandler()
    ];

    public override object? Execute(Context context, Command command)
    {
        foreach (var o in command.Options)
        {
            foreach (var attr in o.Attributes)
            {
                _optionHandlers
                    .FirstOrDefault(handler => handler.Is(attr))?
                    .Handle(attr, o)
                    .Invoke(command.Instance.Value, context.Data);
            }
        }

        foreach (var action in command.Actions)
        {
            action.Invoke(command.Instance.Value, null);
        }

        return null;
    }
}