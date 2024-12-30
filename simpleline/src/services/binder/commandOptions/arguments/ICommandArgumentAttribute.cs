using simpleline.models.options;
using simpleline.models.options.commands;

namespace simpleline.services.binder.commandOptions.arguments;

internal interface ICommandArgumentAttribute : ICommandOptionAttribute
{
    public int Position { get; }
}