using simpleline.models.attributes;

namespace simpleline.services.binder.commandOptions.arguments;

public interface IArgumentAttribute : IOptionAttribute
{
    public int Position { get; }
    public int Arity { get; }
}