using simpleline.models.options.actions;

namespace simpleline.services.executor.main.binder.actionOptions.arguments;

internal interface IActionArgumentAttribute : IActionOptionAttribute {
    int Position { get; }
    int Arity { get; }
}