using simpleline.models.options.actions;

namespace simpleline.services.executor.main.binder.actionOptions.parameters;

internal interface IActionParameterAttribute : IActionOptionAttribute {
    ICollection<string> Keys { get; }
    int Arity { get; }
}