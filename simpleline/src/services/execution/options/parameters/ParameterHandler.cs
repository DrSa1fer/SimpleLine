using simpleline.models.commands;

namespace simpleline.services.execution.options.parameters;

public class ParameterHandler :  OptionHandlerBase<IParameterAttribute>
{
    protected override InitOptionDelegate Handle(IParameterAttribute attribute, Option option)
    {
        return (instance, data) =>
        {
            option.SetValue(instance, 10);
        };
    }
}