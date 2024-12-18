using simpleline.models.commands;
using simpleline.models;

namespace simpleline.services.execution.options;

public abstract class OptionHandlerBase
{
    public abstract bool Is(IOptionAttribute attribute);
    public abstract InitOptionDelegate Handle(IOptionAttribute attribute, Option option);
}