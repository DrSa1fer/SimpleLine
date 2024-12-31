using simpleline.models.options.actions;

namespace simpleline.services.binder.actionOptions.arguments;

internal interface IActionArgumentAttribute : IActionOptionAttribute
{
    public int Position { get; }
}