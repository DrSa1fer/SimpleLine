using simpleline.models.options;

namespace simpleline.services.binder.actionOptions.flags;

public interface IFlagAttribute : ICommandOptionAttribute
{
    public IEnumerable<string> Keys { get; }
}