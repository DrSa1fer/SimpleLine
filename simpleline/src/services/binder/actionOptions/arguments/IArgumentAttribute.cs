using simpleline.models.options;

namespace simpleline.services.binder.actionOptions.arguments;

public interface IArgumentAttribute : ICommandOptionAttribute
{
    public int Position { get; }
    public int Arity { get; }
}