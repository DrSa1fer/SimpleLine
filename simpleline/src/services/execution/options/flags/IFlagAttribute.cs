using simpleline.models;
using simpleline.models.attributes;

namespace simpleline.services.execution.options.flags;

public interface IFlagAttribute : IOptionAttribute
{
    public IEnumerable<string> Keys { get; }
}