using simpleline.models.commands;

namespace simpleline.services.execution.options.arguments;

public class ArgumentHandler : OptionHandlerBase<IArgumentAttribute>
{
    protected override InitOptionDelegate Handle(IArgumentAttribute attribute, Option option)
    {
        return (instance, data) =>
        {
            option.SetValue(instance, 9);
        };
    }
}