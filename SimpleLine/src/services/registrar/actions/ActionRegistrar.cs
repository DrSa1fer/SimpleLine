using System.Reflection;
using simpleline.models.actions;
using simpleline.services.registrar.options.actions;
using Action = simpleline.models.actions.Action;

namespace simpleline.services.registrar.actions;

internal class ActionRegistrar(ActionOptionRegistrarBase optionRegistrar) : ActionRegistrarBase {
    public override Action[] GetActions(MethodInfo[] methodsInfo, object? instance) {
        var mArr = Filter.Methods(methodsInfo).ToArray();
        var aArr = new Action[mArr.Length];

        for (var i = 0; i < mArr.Length; i++) {
            var m = mArr[i];

            var attrs = m
                .GetCustomAttributes()
                .OfType<IActionAttribute>()
                .ToList();

            var parameters = m.GetParameters();
            var options = optionRegistrar.GetActionOptions(parameters);
            
            aArr[i] = new Action(
                attrs,
                options,
                args => m.Invoke(instance, args)
            );
        }

        return aArr;
    }
}