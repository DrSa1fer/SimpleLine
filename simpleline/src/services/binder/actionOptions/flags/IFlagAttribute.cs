using simpleline.models.attributes;

namespace simpleline.services.binder.actionOptions.flags;

public interface IFlagAttribute : IOptionAttribute
{
    public IEnumerable<string> Keys { get; }
}