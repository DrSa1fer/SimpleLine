using simpleline.models.options;
using simpleline.services.executor.main.binder.handlers;
using simpleline.services.executor.main.binder.handlers.arguments;
using simpleline.services.executor.main.binder.handlers.envs;
using simpleline.services.executor.main.binder.handlers.flags;
using simpleline.services.executor.main.binder.handlers.parameters;

namespace simpleline.services.executor.main.binder;

internal class Binder(ParameterHandler ph, ArgumentHandler ah, FlagHandler fh, EnvHandler eh) : BinderBase {
    private readonly KeyValuePair<Type, HandleDelegate>[] _initHandlers = [
        new(
            typeof(IParameterAttribute),
            (attr, opt, data) => ph.Handle((IParameterAttribute)attr, opt, data)
        ),
        new(
            typeof(IArgumentAttribute),
            (attr, opt, data) => ah.Handle((IArgumentAttribute)attr, opt, data)
        ),
        new(
            typeof(IFlagAttribute),
            (attr, opt, data) => fh.Handle((IFlagAttribute)attr, opt, data)
        ),
        new(
            typeof(IEnvAttribute),
            (attr, option, data) => eh.Handle((IEnvAttribute)attr, option, data)
        )
    ];
    
    protected override void OnBind(IEnumerable<Option> options, Data data) {
        foreach (var option in options) {
            foreach (var attribute in option.Attributes) {
                if (_initHandlers.FirstOrDefault(x => x.Key.IsAssignableTo(attribute.GetType())) is {} handler) {
                    handler.Value(attribute, option, data);
                }
            }
        }
    }
}