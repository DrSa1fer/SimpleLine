using simpleline.models.attributes;

namespace simpleline.services.execution.options.arguments;

public interface IArgumentAttribute : IOptionAttribute
{
    public int Position { get; }
    public int Arity { get; }
}