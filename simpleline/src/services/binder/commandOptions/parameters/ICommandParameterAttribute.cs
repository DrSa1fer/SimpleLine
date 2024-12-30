using simpleline.models.options;
using simpleline.models.options.commands;

namespace simpleline.services.binder.commandOptions.parameters;

internal interface ICommandParameterAttribute : ICommandOptionAttribute
{
    public IEnumerable<string> Keys { get; }
}