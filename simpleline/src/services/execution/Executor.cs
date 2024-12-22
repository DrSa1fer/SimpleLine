using simpleline.models;
using simpleline.services.execution.options;

namespace simpleline.services.execution;

public class Executor : ExecutorBase
{
    private readonly OptionHandlerBase[] _optionHandlers =
    [
    ];

    public override object? Execute(Context context, Command command)
    {
        foreach (var option in command.Options)
        {
            foreach (var attr in option.Attributes)
            {
                _optionHandlers
                    .FirstOrDefault(handler => handler.Is(attr))?
                    .Handle(attr, option)
                    .Invoke(context.Data);
            }
        }

        foreach (var action in command.Actions)
        {
            action.Invoke(null);
        }

        return null;
    }
}