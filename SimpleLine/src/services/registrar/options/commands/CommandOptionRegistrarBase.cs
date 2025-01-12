using System.Reflection;
using simpleline.models.options;

namespace simpleline.services.registrar.options.commands;

internal abstract class CommandOptionRegistrarBase {
    public abstract Option[] GetCommandOptions(FieldInfo[] fieldsInfo, PropertyInfo[] propertiesInfo,
        object? instance);
}