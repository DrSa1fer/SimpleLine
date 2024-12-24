using simpleline.models;
using simpleline.models.attributes;
using simpleline.models.inputs;

namespace simpleline.services.binder.commandOptions;

public abstract class CommandOptionHandlerBase
{
    public abstract bool Is(IOptionAttribute attribute);
    public abstract void Handle(IOptionAttribute attribute, CommandOption commandOption, Data data);
}