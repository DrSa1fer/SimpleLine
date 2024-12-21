using simpleline.models;
using simpleline.models.attributes;

namespace simpleline.services.execution.options;

public abstract class OptionHandlerBase
{
    public abstract bool Is(IOptionAttribute attribute);
    public abstract InitOptionDelegate Handle(IOptionAttribute attribute, Option option);
}