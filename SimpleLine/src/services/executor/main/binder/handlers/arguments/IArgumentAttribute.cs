using simpleline.models.options;

namespace simpleline.services.executor.main.binder.handlers.arguments;

internal interface IArgumentAttribute : IOptionAttribute {
    int Position { get; }
    int Arity { get; }
}