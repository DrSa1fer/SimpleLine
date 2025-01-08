using simpleline.models.options.actions;

namespace simpleline.services.executor.main.binder.actionOptions.parameters;

internal interface IActionParameterAttribute : IActionOptionAttribute {
    public IEnumerable<string> Keys { get; }
}