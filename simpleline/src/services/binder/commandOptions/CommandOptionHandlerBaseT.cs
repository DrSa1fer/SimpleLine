using simpleline.models.options.commands;

namespace simpleline.services.binder.commandOptions;

internal abstract class CommandOptionHandlerBase<T> : CommandOptionHandlerBase where T : ICommandOptionAttribute
{
    public override bool Is(ICommandOptionAttribute attribute)
    {
        return attribute is T;
    }

    public override void Handle(ICommandOptionAttribute attribute, CommandOption option, InputData inputData)
    {
        OnHandle((T)attribute, option, inputData);
    }

    protected abstract void OnHandle(T attribute, CommandOption option, InputData inputData);
}