using simpleline.models.options;
using simpleline.services.executor.main.binder.handlers;
using simpleline.services.executor.main.binder.handlers.arguments;
using simpleline.services.executor.main.binder.handlers.flags;
using simpleline.services.executor.main.binder.handlers.parameters;

namespace simpleline.services.executor.main.binder;

internal class Binder : BinderBase {
    private readonly Handler[] _handlers = [];
    //
    public Binder(ParameterHandler aph, ArgumentHandler aah, FlagHandler afh) 
    {
        
    }
    //
    // protected override void OnBind(IEnumerable<Option> options, Data data) {
    //     foreach (var option in options) {
    //         foreach (var attribute in option.Attributes) {
    //             if (_handlers.TryGetValue()) {
    //                 continue;
    //             }
    //
    //             var value = handler.Handle(attribute, option.Type, data);
    //             option.Set(value);
    //         }
    //     }
    // }
    protected override void OnBind(IEnumerable<Option> options, Data data) {
        throw new NotImplementedException();
    }
}