using simpleline.models.options;

namespace simpleline.services.executor.main.binder.options.parameters;

internal interface IParameterAttribute : IOptionAttribute {
    ICollection<string> Keys { get; }
    int Arity { get; }
}