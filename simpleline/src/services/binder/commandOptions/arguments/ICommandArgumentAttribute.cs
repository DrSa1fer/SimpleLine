using simpleline.models.options;

namespace simpleline.services.binder.commandOptions.arguments;

public interface ICommandArgumentAttribute : ICommandOptionAttribute
{
    public int Position { get; }
}