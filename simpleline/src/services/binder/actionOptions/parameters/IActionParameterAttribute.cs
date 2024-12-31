using simpleline.models.options.actions;

namespace simpleline.services.binder.actionOptions.parameters;

internal interface IActionParameterAttribute : IActionOptionAttribute
{
    public IEnumerable<string> Keys { get; }
}