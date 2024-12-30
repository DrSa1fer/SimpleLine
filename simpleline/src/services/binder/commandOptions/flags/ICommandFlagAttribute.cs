using simpleline.models.options;

namespace simpleline.services.binder.commandOptions.flags;

public interface ICommandFlagAttribute : ICommandOptionAttribute
{
    public IEnumerable<string> Keys { get; }
}