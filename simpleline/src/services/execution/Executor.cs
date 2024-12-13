using simpleline.models;

namespace simpleline.services.execution;

public class Executor : ExecutorBase
{
    public override void Execute(Input input, Controller controller)
    {
        controller.Actions
            .FirstOrDefault(x => x.Is(input))?
            .Do(input);
    }
}