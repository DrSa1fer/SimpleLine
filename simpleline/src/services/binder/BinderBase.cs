using simpleline.models;

namespace simpleline.services.binder;

public abstract class BinderBase
{
    public abstract void Bind(ActionOption option);
    public abstract void Bind(CommandOption option);
}