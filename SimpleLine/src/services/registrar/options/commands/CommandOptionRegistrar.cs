using System.Reflection;
using simpleline.models.options;

namespace simpleline.services.registrar.options.commands;

internal class CommandOptionRegistrar : CommandOptionRegistrarBase {
    public override Option[] GetCommandOptions(FieldInfo[] fieldsInfo, PropertyInfo[] propertiesInfo, object? instance) {
        var pArr = Filter.Properties(propertiesInfo).ToList();
        var fArr = Filter.Fields(fieldsInfo).ToList();

        var i = 0;
        var oArr = new Option[pArr.Count + fArr.Count];

        for (var j = 0; j < pArr.Count; j++, i++) {
            var p = pArr[j];

            var attrs = p
                .GetCustomAttributes()
                .OfType<IOptionAttribute>()
                .ToList();

            oArr[i] = new Option(
                attrs,
                () => p.GetValue(instance),
                value => p.SetValue(instance, value),
                p.PropertyType
            );
        }

        for (var j = 0; j < fArr.Count; j++, i++) {
            var f = fArr[j];

            var attrs = f
                .GetCustomAttributes()
                .OfType<IOptionAttribute>()
                .ToList();

            oArr[i] = new Option(
                attrs,
                () => f.GetValue(instance),
                value => f.SetValue(instance, value),
                f.FieldType
            );
        }

        return oArr;
    }
}