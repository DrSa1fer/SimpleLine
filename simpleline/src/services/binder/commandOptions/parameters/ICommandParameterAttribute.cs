using simpleline.models.options;

namespace simpleline.services.binder.commandOptions.parameters;

public interface ICommandParameterAttribute : ICommandOptionAttribute
{
    public IEnumerable<string> Keys { get; }
}