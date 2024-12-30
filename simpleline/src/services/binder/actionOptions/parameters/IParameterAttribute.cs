using simpleline.models.options;

namespace simpleline.services.binder.actionOptions.parameters;

public interface IParameterAttribute : ICommandOptionAttribute
{
    public IEnumerable<string> Keys { get; }
    public int Arity { get; }
}