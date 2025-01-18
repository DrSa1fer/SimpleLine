using simpleline.models.options;

namespace simpleline.services.executor.main.binder.handlers.parameters;

internal interface IParameterAttribute : IOptionAttribute {
    ICollection<string> Aliases { get; }
    int Arity { get; }
}