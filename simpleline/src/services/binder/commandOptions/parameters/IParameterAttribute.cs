using simpleline.models.attributes;

namespace simpleline.services.binder.commandOptions.parameters;

public interface IParameterAttribute : IOptionAttribute
{
    public IEnumerable<string> Keys { get; }
    public int Arity { get; }
}