using simpleline.models;
using simpleline.models.commands;

namespace simpleline.services.execution;

public class Executor : ExecutorBase
{
    public override void Execute(Context context, Command? command)
    {
        command?.Actions.FirstOrDefault()?.Invoke(null);
    }
}