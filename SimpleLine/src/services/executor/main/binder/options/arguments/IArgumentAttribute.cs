using simpleline.models.options;

namespace simpleline.services.executor.main.binder.options.arguments;

internal interface IArgumentAttribute : IOptionAttribute {
    int Position { get; }
    int Arity { get; }
}