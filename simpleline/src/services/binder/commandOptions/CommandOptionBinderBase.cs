using simpleline.models;
using simpleline.models.inputs;

namespace simpleline.services.binder.commandOptions;

public abstract class CommandOptionBinderBase
{
    public abstract void Bind(CommandOption option, Data data); 
}