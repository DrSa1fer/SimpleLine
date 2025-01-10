using simpleline.models.options.actions;

namespace simpleline.services.executor.main.binder.actionOptions.flags;

internal interface IActionFlagAttribute : IActionOptionAttribute {
    ICollection<string> Keys { get; }
}