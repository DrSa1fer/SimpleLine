using simpleline.models;
using simpleline.models.attributes;
using simpleline.models.inputs;

namespace simpleline.services.binder.actionOptions;

public abstract class ActionOptionHandlerBase
{
    public abstract bool Is(IOptionAttribute attribute);
    public abstract void Handle(IOptionAttribute attribute, CommandOption commandOption, Data data);
}