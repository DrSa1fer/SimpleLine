using System.Reflection;
using simpleline.models.actions;
using simpleline.models.commands;
using simpleline.models.options.actions;
using simpleline.models.options.commands;
using Action = simpleline.models.actions.Action;

namespace simpleline.workers.registrar;

internal class Registrar : RegistrarBase
{
    public override Command[] Register(IEnumerable<Assembly> assemblies)
    {
        var e = Enumerable.Empty<Command>();

        foreach (var assembly in assemblies)
        {
            e = e.Concat(GetCommands(assembly));
        }
        
        return e.ToArray();
    }

    private static Command[] GetCommands(Assembly assembly)
    {
        var tArr = Filter.Types(assembly.DefinedTypes).ToArray();
        var cArr = new Command[tArr.Length];

        for (var i = 0; i < cArr.Length; i++)
        {
            var attrs = tArr[i]
                .GetCustomAttributes()
                .OfType<ICommandAttribute>()
                .ToArray();

            var instance = Activator.CreateInstance(tArr[i]);
            var actions = GetActions(tArr[i], instance);
            var options = GetOptions(tArr[i], instance);

            cArr[i] = new Command(attrs, actions, options);
        }

        return cArr;
    }

    private static Action[] GetActions(Type type, object? instance)
    {
        var mArr = Filter.Methods(type.GetMethods()).ToArray();
        var aArr = new Action[mArr.Length];

        for (var i = 0; i < mArr.Length; i++)
        {
            var m = mArr[i];

            var attrs = m
                .GetCustomAttributes()
                .OfType<IActionAttribute>()
                .ToArray();

            var parameters = m.GetParameters();
            
            var options = new ActionOption[parameters.Length];
            var values = new object?[options.Length];

            for (var j = 0; j < parameters.Length; j++)
            {
                var p = parameters[j];
                
                var oAttrs = p
                    .GetCustomAttributes()
                    .OfType<IActionOptionAttribute>()
                    .ToArray();

                var v = j;
                options[j] = new ActionOption(
                    oAttrs,
                    value => values[v] = value,
                    p.ParameterType
                );
            }

            aArr[i] = new Action(
                attrs,
                options,
                () => m.Invoke(instance, values)
            );
        }

        return aArr;
    }
    
    private static CommandOption[] GetOptions(Type type, object? instance)
    {
        var pArr = Filter.Properties(type.GetProperties()).ToArray();
        var fArr = Filter.Fields(type.GetFields()).ToArray();

        var i = 0;
        var oArr = new CommandOption[pArr.Length + fArr.Length];


        for (var j = 0; j < pArr.Length; j++, i++)
        {
            var p = pArr[j];

            var attrs = p
                .GetCustomAttributes()
                .OfType<ICommandOptionAttribute>()
                .ToArray();

            oArr[i] = new CommandOption(
                attrs,
                value => p.SetValue(instance, value),
                p.PropertyType
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
                value => f.SetValue(instance, value),
                f.FieldType
            );
        }

        return oArr;
    }
}