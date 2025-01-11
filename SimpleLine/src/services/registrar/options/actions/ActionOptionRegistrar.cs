using System.Reflection;
using simpleline.models.options.actions;

namespace simpleline.services.registrar.options.actions;

internal class ActionOptionRegistrar : ActionOptionRegistrarBase {
    public override ActionOption[] GetActionOptions(ParameterInfo[] parametersInfo, object?[] sync) {
        var options = new ActionOption[parametersInfo.Length];

        for (var j = 0; j < parametersInfo.Length; j++) {
            var p = parametersInfo[j];

            var oAttrs = p
                .GetCustomAttributes()
                .OfType<IActionOptionAttribute>()
                .ToArray();

            var v = j;
            options[j] = new ActionOption(
                oAttrs,
                value => sync[v] = value,
                p.ParameterType
            );
        }

        return options;
    }
}