using simpleline.models;

namespace simpleline.services.execution.options.parameters;

public class ParameterHandler : OptionHandlerBase<IParameterAttribute>
{
    protected override InitOptionDelegate Handle(IParameterAttribute attribute, Option option)
    {
        return data => { option.SetValue(10); };
    }
}