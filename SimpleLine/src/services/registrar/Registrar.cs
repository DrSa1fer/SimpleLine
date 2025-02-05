using System.Reflection;
using simpleline.models.actions;
using simpleline.models.commands;
using simpleline.models.options;
using Action = simpleline.models.actions.Action;

namespace simpleline.services.registrar;

internal class Registrar : RegistrarBase {
    protected override Command[] OnRegister(IEnumerable<TypeInfo> types) {
        return GetCommands(types).ToArray();
    }
    
    private static Command[] GetCommands(IEnumerable<TypeInfo> types) {
        var tArr = Filter.Types(types).ToArray();
        var cArr = new Command[tArr.Length];

        for (var i = 0; i < cArr.Length; i++) {
            var attrs = tArr[i]
                .GetCustomAttributes()
                .OfType<ICommandAttribute>()
                .ToList();

            var properties = tArr[i].GetProperties();
            var methods = tArr[i].GetMethods();
            var fields = tArr[i].GetFields();

            var instance = Activator.CreateInstance(tArr[i]);
            var actions = GetActions(methods, instance);
            var options = GetCommandOptions(fields, properties, instance);

            cArr[i] = new Command(attrs, actions, options);
        }

        return cArr;
    }
    
    private static Option[] GetCommandOptions(FieldInfo[] fieldsInfo, PropertyInfo[] propertiesInfo, object? instance) {
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
    
    private static Action[] GetActions(MethodInfo[] methodsInfo, object? instance) {
        var mArr = Filter.Methods(methodsInfo).ToArray();
        var aArr = new Action[mArr.Length];

        for (var i = 0; i < mArr.Length; i++) {
            var m = mArr[i];

            var attrs = m
                .GetCustomAttributes()
                .OfType<IActionAttribute>()
                .ToList();

            var parameters = m.GetParameters();
            var options = GetActionOptions(parameters);
            
            aArr[i] = new Action(
                attrs,
                options,
                args => m.Invoke(instance, args)
            );
        }

        return aArr;
    }
    
    private static Option[] GetActionOptions(ParameterInfo[] parametersInfo) {
        var options = new Option[parametersInfo.Length];
        var sync = new object?[parametersInfo.Length];
        
        for (var j = 0; j < parametersInfo.Length; j++) {
            var p = parametersInfo[j];

            var oAttrs = p
                .GetCustomAttributes()
                .OfType<IOptionAttribute>()
                .ToArray();

            var v = j;
            options[j] = new Option(
                oAttrs,
                () => sync[v],
                value => sync[v] = value,
                p.ParameterType
            );
        }

        return options;
    }
}