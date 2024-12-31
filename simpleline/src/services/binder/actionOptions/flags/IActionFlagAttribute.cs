using simpleline.models.options.actions;

namespace simpleline.services.binder.actionOptions.flags;

internal interface IActionFlagAttribute : IActionOptionAttribute
{
    public IEnumerable<string> Keys { get; }
}