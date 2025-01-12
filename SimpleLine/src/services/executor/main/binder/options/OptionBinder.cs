using simpleline.models.options;
using simpleline.services.executor.main.binder.options.arguments;
using simpleline.services.executor.main.binder.options.flags;
using simpleline.services.executor.main.binder.options.parameters;

namespace simpleline.services.executor.main.binder.options;

internal class OptionBinder(
    ParameterHandler aph,
    ArgumentHandler aah,
    FlagHandler afh
) : OptionBinderBase {
    private readonly OptionHandlerBase[] _handlers = [aph, aah, afh];

    protected override void OnBind(IEnumerable<Option> options, Data data) {
        foreach (var option in options) {
            foreach (var attribute in option.Attributes) {
                if (_handlers.FirstOrDefault(x => x.Is(attribute)) is not { } handler) {
                    continue;
                }

                var value = handler.Handle(attribute, option.Type, data);
                option.Init(value);
            }
        }
    }
}