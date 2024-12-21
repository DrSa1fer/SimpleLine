using simpleline.models;

namespace simpleline.services.execution.options.arguments;

public class ArgumentHandler : OptionHandlerBase<IArgumentAttribute>
{
    protected override InitOptionDelegate Handle(IArgumentAttribute attribute, Option option)
    {
        return data => { option.SetValue(9); };
    }
}