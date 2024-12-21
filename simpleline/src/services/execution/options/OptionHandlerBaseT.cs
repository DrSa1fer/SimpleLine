using simpleline.models;
using simpleline.models.attributes;

namespace simpleline.services.execution.options;

public abstract class OptionHandlerBase<T> : OptionHandlerBase where T : IOptionAttribute
{
    public sealed override bool Is(IOptionAttribute attribute)
    {
        return attribute is T;
    }

    public sealed override InitOptionDelegate Handle(IOptionAttribute attribute, Option option)
    {
        return Handle((T)attribute, option);
    }

    protected abstract InitOptionDelegate Handle(T attribute, Option option);
}