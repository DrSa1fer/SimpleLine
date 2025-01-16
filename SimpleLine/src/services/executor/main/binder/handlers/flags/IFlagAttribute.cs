using simpleline.models.options;

namespace simpleline.services.executor.main.binder.handlers.flags;

internal interface IFlagAttribute : IOptionAttribute {
    ICollection<string> Keys { get; }
}