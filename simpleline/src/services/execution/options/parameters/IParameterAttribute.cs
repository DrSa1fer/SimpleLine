using simpleline.models;
using simpleline.models.attributes;

namespace simpleline.services.execution.options.parameters;

public interface IParameterAttribute : IOptionAttribute
{
    public IEnumerable<string> Keys { get; }
    public int Arity { get; }
}