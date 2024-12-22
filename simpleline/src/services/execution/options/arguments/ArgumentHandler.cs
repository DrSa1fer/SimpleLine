using simpleline.models;
using simpleline.parsers;

namespace simpleline.services.execution.options.arguments;

public class ArgumentHandler(ParserProvider provider) : OptionHandlerBase<IArgumentAttribute>
{
    protected override InitOptionDelegate Handle(IArgumentAttribute attribute, Option option)
    {
        return data =>
        {
            if (!data.TryGetValue(attribute.Position, 0, out var values))
            {
                return;
            }

            var objects = provider.Parse(option.Type, values);
            
            option.SetValue(objects);
        };
    }
}