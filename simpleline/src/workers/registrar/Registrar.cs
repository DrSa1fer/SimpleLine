using System.Reflection;
using simpleline.models.actions;
using simpleline.models.commands;
using simpleline.models.options;
using simpleline.models.options.actions;
using simpleline.models.options.commands;
using simpleline.models.scopes;
using Action = simpleline.models.actions.Action;

namespace simpleline.workers.registrar;

internal class Registrar : RegistrarBase
{
    public override Scope[] Register(IEnumerable<Assembly> assemblies)
    {
        return GetScopes(assemblies);
    }

    private static Scope[] GetScopes(IEnumerable<Assembly> assemblies)
    {
        var aArr = assemblies.ToArray();
        var sArr = new Scope[aArr.Length];

        for (var i = 0; i < aArr.Length; i++)
        {
            var attrs = aArr[i]
                .GetCustomAttributes()
                .OfType<IScopeAttribute>()
                .ToArray();

            var commands = GetCommands(aArr[i]);

            sArr[i] = new Scope(attrs, commands);
        }

        return sArr;
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

            var options = GetActionOptions(m);

            var invoke = new Action.InvokeDelegate(() =>
            {
                var arr = new object?[options.Length];
                for (var j = 0; j < options.Length; j++) arr[j] = options[j].GetValue();

                return m.Invoke(instance, arr);
            });

            aArr[i] = new Action(
                attrs,
                options,
                m.ReturnType,
                invoke
            );
        }

        return aArr;
    }

    private static ActionOption[] GetActionOptions(MethodInfo method)
    {
        var parameters = method.GetParameters();
        var arr = new ActionOption[parameters.Length];

        for (var i = 0; i < parameters.Length; i++)
        {
            var p = parameters[i];

            var attrs = p
                .GetCustomAttributes()
                .OfType<IActionOptionAttribute>()
                .ToArray();

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