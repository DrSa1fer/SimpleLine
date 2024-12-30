using System.Reflection;
using simpleline.models.actions;
using simpleline.models.commands;
using simpleline.models.options;
using Action = simpleline.models.actions.Action;

namespace simpleline.workers.registrar;

public class Registrar : RegistrarBase
{
    public override IEnumerable<Command> Register(IEnumerable<TypeInfo> types)
    {
        foreach (var type in Filter.Types(types))
        {
            var attrs = type.GetCustomAttributes()
                .OfType<ICommandAttribute>();

            var instance = Activator.CreateInstance(type);
            var actions = GetActions(type, instance);
            var options = GetOptions(type, instance);

            yield return new Command(attrs, actions, options);
        }
    }
    private static Action[] GetActions(Type type, object? instance)
    {
        var mArr = Filter.Methods(type.GetMethods()).ToArray();
        var aArr = new Action[mArr.Length];
        
        for(var i = 0; i < mArr.Length; i++)
        {
            var m = mArr[i];

            var attrs = m
                .GetCustomAttributes()
                .OfType<IActionAttribute>();

            var options = GetActionOptions(m.GetParameters());
            
            aArr[i] = new Action(
                attrs,
                options,
                m.ReturnType,
                args => m.Invoke(instance, args)
            );
        }

        return aArr;
    }
    private static ActionOption[] GetActionOptions(ParameterInfo[] parameters)
    {
        var arr = new ActionOption[parameters.Length];

        for (var i = 0; i < parameters.Length; i++)
        {
            var p = parameters[i];

            var attrs = p
                .GetCustomAttributes()
                .OfType<IActionOptionAttribute>();

            arr[i] = new ActionOption(
                attrs,
                p.ParameterType,
                p.IsOptional == false,
                p.IsOptional,
                p.DefaultValue
            );
        }

        return arr;
    }
    private static CommandOption[] GetOptions(Type type, object? instance)
    {
        var pArr = Filter.Properties(type.GetProperties()).ToArray();
        var fArr = Filter.Fields(type.GetFields()).ToArray();
        
        var oArr = new CommandOption[pArr.Length + fArr.Length];
        
        var i = 0;
        
        for (var j = 0; j < pArr.Length; j++, i++)
        {
            var p = pArr[j];

            var attrs = p
                .GetCustomAttributes()
                .OfType<ICommandOptionAttribute>();
            
            oArr[i] = new CommandOption(
                attrs,
                () => p.GetValue(instance),
                va => p.SetValue(instance, va),
                p.PropertyType,
                true,
                false,
                null
            );
        }
        
        for (var j = 0; j < fArr.Length; j++, i++)
        {
            var f = fArr[j];
            
            var attrs = f
                .GetCustomAttributes()
                .OfType<ICommandOptionAttribute>()
                .ToArray();
            
            oArr[i] = new CommandOption(
                attrs,
                () => f.GetValue(instance),
                va => f.SetValue(instance, va),
                f.FieldType,
                true,
                false,
                null
            );
        }
        
        return oArr;
    }
}