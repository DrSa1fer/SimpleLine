using simpleline.models.options.actions;
using simpleline.services.executor.main.typizer;

namespace simpleline.services.executor.main.binder.actionOptions.parameters;

internal class ActionParameterHandler(TypizerBase typizer) : ActionOptionHandlerBase<IActionParameterAttribute>
{
    protected override void OnHandle(IActionParameterAttribute attribute, ActionOption option, Data data)
    {
        foreach (var key in attribute.Keys)
        {
            if (!data.TryGetValues(key, 1, out var values)) continue;

            option.Init(typizer.Typize(option.Type, [values[1]]));
            return;
        }

        throw new Exception("Key not found");
    }
}