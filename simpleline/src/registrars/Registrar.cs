using System.Reflection;
using simpleline.models;
using simpleline.models.attributes;
using Action = simpleline.models.Action;

namespace simpleline.registrars;

public class Registrar : RegistrarBase
{
    public override IEnumerable<Command> Register(IEnumerable<TypeInfo> types)
    {
        var filtered = types
            .Where(typeInfo => typeInfo is
                {
                    IsClass: true,
                    IsAbstract: false,
                    IsGenericType: false
                }
            )
            .Where(typeInfo => typeInfo
                .GetCustomAttributes()
                .OfType<IRegistered>()
                .Any()
            );

        foreach (var type in filtered)
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
        foreach (var method in type.GetMethods())
        {
            var attrs = new AttributeCollection<IActionAttribute>(method
                .GetCustomAttributes()
                .OfType<IActionAttribute>()
            );

            if (attrs.Count < 1)
                continue;

            var options = GetActionOptions(method.GetParameters());

            yield return new Action(
                attrs,
                options,
                method.ReturnType,
                args => method.Invoke(instance, args)
            );
        }

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

    private static IEnumerable<Option> GetOptions(Type type, object? instance)
    {
        foreach (var field in type.GetFields())
        {
            var attrs = new AttributeCollection<IOptionAttribute>(field
                .GetCustomAttributes()
                .OfType<IOptionAttribute>());

            if (attrs.Count < 1)
                continue;

            yield return new Option(
                attrs,
                () => field.GetValue(instance),
                va => field.SetValue(instance, va),
                field.FieldType,
                true,
                false,
                null
            );
        }

        foreach (var prop in type.GetProperties())
        {
            var attrs = new AttributeCollection<IOptionAttribute>(prop
                .GetCustomAttributes()
                .OfType<IOptionAttribute>()
            );

            if (attrs.Count < 1)
                continue;

            yield return new Option(
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