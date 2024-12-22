using simpleline.models;
using simpleline.parsers;

namespace simpleline.services.execution.options.flags;

public class FlagHandler(ParserProvider provider) : OptionHandlerBase<IFlagAttribute>
{
    protected override InitOptionDelegate Handle(IFlagAttribute attribute, Option option)
    {
        return data =>
        {   
            if(!option.Type.IsAssignableTo(typeof(bool)))
            {
                throw new ArgumentException("Flag type must be bool");
            }

            option.SetValue(attribute.Keys.Any(key => data.TryGetValue(key, 0, out _)));
        };
    }
}