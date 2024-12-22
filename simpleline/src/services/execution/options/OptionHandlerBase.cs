using simpleline.models;
using simpleline.models.attributes;
using simpleline.parsers;

namespace simpleline.services.execution.options;

public abstract class OptionHandlerBase
{
    public abstract bool Is(IOptionAttribute attribute);
    public abstract InitOptionDelegate Handle(IOptionAttribute attribute, Option option);
}