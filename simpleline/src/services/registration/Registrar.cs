using System.Reflection;
using simpleline.models;
using simpleline.models.commands;
using Action = simpleline.models.commands.Action;

namespace simpleline.services.registration;

public class Registrar : RegistrarBase
{
    public override IEnumerable<Command> Register(Context context)
    {
        var filtered = context
            .ApplicationConfig
            .DefinedTypes
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

            Console.WriteLine(type.Name);
            yield return new Command(attrs, actions, options);
        }
    }

    private static IEnumerable<Action> GetActions(Type type)
    {
        foreach (var method in type.GetMethods())
        {
            var attrs = method
                .GetCustomAttributes()
                .OfType<IActionAttribute>();

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
            var attrs = parameters[i]
                .GetCustomAttributes()
                .OfType<IActionOptionAttribute>();
            
            arr[i] = new ActionOption(
                attrs,
                parameters[i].ParameterType,
                !parameters[i].IsOptional,
                parameters[i].IsOptional,
                parameters[i].DefaultValue
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