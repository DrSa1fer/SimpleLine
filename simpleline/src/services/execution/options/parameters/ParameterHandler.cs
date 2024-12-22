using simpleline.models;
using simpleline.parsers;

namespace simpleline.services.execution.options.parameters;

public class ParameterHandler(ParserProvider provider) : OptionHandlerBase<IParameterAttribute>
{
    protected override InitOptionDelegate Handle(IParameterAttribute attribute, Option option)
    {
        return data =>
        {
            foreach (var key in attribute.Keys)
            {
                if (!data.TryGetValue(key, 1, out var value))
                {
                    continue;
                }

                option.SetValue(value);
            }

            throw new Exception();
        };
    }
}