using System.Diagnostics;
using simpleline.models.options.actions;
using simpleline.services.typizer;

namespace simpleline.services.binder.actionOptions.arguments;

internal class ActionArgumentHandler(TypizerBase typizer) : ActionOptionHandlerBase<IActionArgumentAttribute>
{
    protected override void OnHandle(IActionArgumentAttribute attribute, ActionOption option, InputData inputData)
    {
        if (!inputData.TryGetValues(attribute.Position, 1, out var values)) throw new Exception("Key not found");

        option.SetValue(typizer.Typize(option.Type, [values[1]]));
    }
}