using simpleline.models;
using simpleline.models.inputs;

namespace simpleline.services.binder.actionOptions;

public abstract class ActionOptionBinderBase
{
    public abstract void Bind(ActionOption option, Data data); 
}