using System.Reflection;
using simpleline.models;
using simpleline.models.commands;
using Action = simpleline.models.commands.Action;

namespace simpleline.services.registration;

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
            var attrs = type
                .GetCustomAttributes()
                .OfType<ICommandAttribute>();

            var actions = GetActions(type);
            var options = GetOptions(type);
            
            yield return new Command(attrs, actions, options, new Lazy<object?>(() => Activator.CreateInstance(type)));
        }
    }

    private static IEnumerable<Action> GetActions(Type type)
    {
        foreach (var method in type.GetMethods())
        {
            var attrs = method
                .GetCustomAttributes()
                .OfType<IActionAttribute>();
            
            if (!attrs.Any())
                continue;
            
            yield return new Action(
                attrs, 
                GetActionOptions(method.GetParameters()), 
                method.ReturnType, 
                method.Invoke);
        }
    }
    
    private static ActionOption[] GetActionOptions(ParameterInfo[] parameters)
    {
        var arr = new ActionOption[parameters.Length];

        for (var i = 0; i < parameters.Length; i++)
        {
            var p = parameters[i];
            
            var attrs = parameters[i]
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

    private static IEnumerable<Option> GetOptions(Type type)
    {
        foreach (var field in type.GetFields())
        {
            var attrs = field
                .GetCustomAttributes()
                .OfType<IOptionAttribute>();
            
            if (!attrs.Any())
                continue;
            
            yield return new Option(
                attrs,
                field.FieldType,
                true,
                false,
                null,
                field.GetValue,
                field.SetValue
            );
        }

        foreach (var prop in type.GetProperties())
        {
            var attrs = prop
                .GetCustomAttributes()
                .OfType<IOptionAttribute>();
            
            if (!attrs.Any())
                continue;
            
            yield return new Option(
                attrs,
                prop.PropertyType,
                true,
                false,
                null,
                prop.GetValue,
                prop.SetValue
            );
        }
    }
}