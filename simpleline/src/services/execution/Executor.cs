using simpleline.models;
using simpleline.models.commands;

namespace simpleline.services.execution;

public class Executor : ExecutorBase
{
    public override object? Execute(Context context, Command command)
    {
        return command.Actions.FirstOrDefault()?.Invoke(null, null);
    }
}