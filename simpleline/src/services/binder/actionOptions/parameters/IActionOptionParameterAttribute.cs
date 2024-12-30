using simpleline.models.options;
using simpleline.models.options.actions;

namespace simpleline.services.binder.actionOptions.parameters;

internal interface IActionOptionParameterAttribute : IActionOptionAttribute
{
    public IEnumerable<string> Keys { get; }
}