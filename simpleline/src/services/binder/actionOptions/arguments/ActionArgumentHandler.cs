using System.Diagnostics;
using simpleline.models.options.actions;
using simpleline.services.typizer;

namespace simpleline.services.binder.actionOptions.arguments;

internal class ActionArgumentHandler(TypizerBase typizer) : ActionOptionHandlerBase<IActionArgumentAttribute>
{
    protected override void OnHandle(IActionArgumentAttribute attribute, ActionOption option, Data data)
    {
        if (!data.TryGetValues(attribute.Position, 1, out var values)) throw new Exception("Key not found");

        option.Init(typizer.Typize(option.Type, [values[1]]));
    }
}