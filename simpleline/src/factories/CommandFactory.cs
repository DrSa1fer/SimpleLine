using System.Reflection;
using simpleline.models.commands;
using Action = simpleline.models.commands.Action;

namespace simpleline.factories;

public static class CommandFactory
{
    public static Command? CommandFrom(Type type)
    {
        return null;
    }


    public static Option OptionFrom(FieldInfo field)
    {
        return null;
    }

    public static Option OptionFrom(PropertyInfo property)
    {
        throw new NotImplementedException();
    }

    public static Action ActionFrom(MethodInfo method)
    {
        return null;
    }
}