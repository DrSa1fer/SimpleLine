using simpleline.models.options;
using simpleline.models.options.actions;

namespace simpleline.services.binder.actionOptions.arguments;

internal interface IActionOptionArgumentAttribute : IActionOptionAttribute
{
    public int Position { get; }
}