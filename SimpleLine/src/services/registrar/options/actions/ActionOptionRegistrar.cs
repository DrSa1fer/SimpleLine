using System.Reflection;
using simpleline.models.options;

namespace simpleline.services.registrar.options.actions;

internal class ActionOptionRegistrar : ActionOptionRegistrarBase {
    public override Option[] GetActionOptions(ParameterInfo[] parametersInfo, object?[] sync) {
        var options = new Option[parametersInfo.Length];

        for (var j = 0; j < parametersInfo.Length; j++) {
            var p = parametersInfo[j];

            var oAttrs = p
                .GetCustomAttributes()
                .OfType<IOptionAttribute>()
                .ToArray();

            var v = j;
            options[j] = new Option(
                oAttrs,
                value => sync[v] = value,
                p.ParameterType
            );
        }

        return options;
    }
}