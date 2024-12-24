using simpleline.models.attributes;

namespace simpleline.services.binder.commandOptions.flags;

public interface IFlagAttribute : IOptionAttribute
{
    public IEnumerable<string> Keys { get; }
}