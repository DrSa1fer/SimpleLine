using simpleline.models.options;
using simpleline.services.executor.main.binder.handlers.arguments;
using simpleline.services.executor.main.binder.handlers.envs;
using simpleline.services.executor.main.binder.handlers.flags;
using simpleline.services.executor.main.binder.handlers.parameters;
using simpleline.services.executor.typizer;

namespace simpleline.services.executor.main.binder;

internal class Binder(ParameterHandler ph, ArgumentHandler ah, FlagHandler fh, EnvHandler eh, 
    TypizerBase typizer) : BinderBase {
    
    /// <summary>
    /// Untyped handler`s action and condition pair
    /// </summary>
    /// <param name="Type">Handler target type</param>
    /// <param name="func">Handler action</param>
    private record UPair(Type Type, Func<IOptionAttribute, DataInput, IEnumerable<string>> func);
    /// <summary>
    /// Typed handler`s action and condition pair
    /// </summary>
    /// <param name="Type">Handler target type</param>
    /// <param name="func">Handler action</param>
    private record TPair(Type Type, Func<IOptionAttribute, DataInput, object?> func);
    
    private readonly UPair[] _uPairs = [
        new(
            typeof(IParameterAttribute),
            (attr, data) => ph.Handle((IParameterAttribute)attr, data)
        ),
        new(
            typeof(IArgumentAttribute),
            (attr, data) => ah.Handle((IArgumentAttribute)attr, data)
        ),
        
        new (
            typeof(IEnvAttribute),
            (attr, _) => eh.Handle((IEnvAttribute)attr)
        )
    ];
    
    private readonly TPair[] _tPairs = [
        new(
            typeof(IFlagAttribute), 
            (attr, data) => fh.Handle((IFlagAttribute)attr, data)
        )
    ];
    
    protected override void OnBind(IEnumerable<Option> options, DataInput dataInput) {
        foreach (var option in options) {
            foreach (var attribute in option.Attributes) {
                if (_uPairs.FirstOrDefault(x => x.Type.IsInstanceOfType(attribute)) is var (_, uFunc)) {
                    var tValue = typizer.Typize(option, uFunc(attribute, dataInput));
                    option.Set(tValue);
                    break;
                }

                if (_tPairs.FirstOrDefault(x => x.Type.IsInstanceOfType(attribute)) is var (_, tFunc)) {
                    var tValue = tFunc(attribute, dataInput);
                    option.Set(tValue);
                    break;
                }
            }
        }
    }
}