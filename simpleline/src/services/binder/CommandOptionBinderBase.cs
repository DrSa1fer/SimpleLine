using simpleline.models.options.commands;

namespace simpleline.services.binder;

internal abstract class CommandOptionBinderBase
{
    public abstract void Bind(IEnumerable<CommandOption> options, InputData data);
}