using simpleline.models.options;
using simpleline.models.options.actions;

namespace simpleline.services.binder.actionOptions.flags;

internal interface IActionOptionFlagAttribute : IActionOptionAttribute
{
    public IEnumerable<string> Keys { get; }
}