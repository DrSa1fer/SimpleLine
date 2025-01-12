using System.Reflection;
using simpleline.models.options;

namespace simpleline.services.registrar.options.commands;

internal class CommandOptionRegistrar : CommandOptionRegistrarBase {
    public override Option[] GetCommandOptions(FieldInfo[] fieldsInfo, PropertyInfo[] propertiesInfo,
        object? instance) {
        var pArr = Filter.Properties(propertiesInfo).ToArray();
        var fArr = Filter.Fields(fieldsInfo).ToArray();

        var i = 0;
        var oArr = new Option[pArr.Length + fArr.Length];


        for (var j = 0; j < pArr.Length; j++, i++) {
            var p = pArr[j];

            var attrs = p
                .GetCustomAttributes()
                .OfType<IOptionAttribute>()
                .ToList();

            oArr[i] = new Option(
                attrs,
                value => p.SetValue(instance, value),
                p.PropertyType
            );
        }

        for (var j = 0; j < fArr.Length; j++, i++) {
            var f = fArr[j];

            var attrs = f
                .GetCustomAttributes()
                .OfType<IOptionAttribute>()
                .ToList();

            oArr[i] = new Option(
                attrs,
                value => f.SetValue(instance, value),
                f.FieldType
            );
        }

        return oArr;
    }
}