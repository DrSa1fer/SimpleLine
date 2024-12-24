using simpleline.models.attributes;

namespace simpleline.services.binder.actionOptions.parameters;

public interface IParameterAttribute : IOptionAttribute
{
    public IEnumerable<string> Keys { get; }
    public int Arity { get; }
}