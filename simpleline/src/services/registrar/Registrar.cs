using System.Reflection;
using simpleline.models;
using simpleline.models.attributes;
using Action = simpleline.models.Action;

namespace simpleline.services.registrar;

public class Registrar : RegistrarBase
{
    public override IEnumerable<Command> Register(IEnumerable<TypeInfo> types)
    {
        foreach (var type in Filter.Types(types))
        {
            var attrs = new AttributeCollection<ICommandAttribute>(type
                .GetCustomAttributes()
                .OfType<ICommandAttribute>()
            );

            var instance = Activator.CreateInstance(type);
            var actions = GetActions(type, instance);
            var options = GetOptions(type, instance);

            yield return new Command(attrs, actions, options);
        }
    }
    
    private static IEnumerable<Action> GetActions(Type type, object? instance)
    {
        foreach (var method in Filter.Methods(type.GetMethods()))
        {
            var attrs = new AttributeCollection<IActionAttribute>(method
                .GetCustomAttributes()
                .OfType<IActionAttribute>()
            );

            var options = GetActionOptions(method.GetParameters());

            yield return new Action(
                attrs,
                options,
                method.ReturnType,
                args => method.Invoke(instance, args)
            );
        }

        yield break;

        ActionOption[] GetActionOptions(ParameterInfo[] parameters)
        {
            var arr = new ActionOption[parameters.Length];

            for (var i = 0; i < parameters.Length; i++)
            {
                var p = parameters[i];

                var attrs = new AttributeCollection<IActionOptionAttribute>(p
                    .GetCustomAttributes()
                    .OfType<IActionOptionAttribute>()
                );

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
    }

    private static IEnumerable<CommandOption> GetOptions(Type type, object? instance)
    {
        foreach (var field in Filter.Fields(type.GetFields()))
        {
            var attrs = new AttributeCollection<IOptionAttribute>(field
                .GetCustomAttributes()
                .OfType<IOptionAttribute>()
            );
            
            yield return new CommandOption(
                attrs,
                () => field.GetValue(instance),
                va => field.SetValue(instance, va),
                field.FieldType,
                true,
                false,
                null
            );
        }

        foreach (var prop in Filter.Properties(type.GetProperties()))
        {
            var attrs = new AttributeCollection<IOptionAttribute>(prop
                .GetCustomAttributes()
                .OfType<IOptionAttribute>()
            );

            yield return new CommandOption(
                attrs,
                () => prop.GetValue(instance),
                va => prop.SetValue(instance, va),
                prop.PropertyType,
                true,
                false,
                null
            );
        }
    }
}