using System.Reflection;
using simpleline.models.options.commands;

namespace simpleline.services.registrar.options.commands;

internal abstract class CommandOptionRegistrarBase {
    public abstract CommandOption[] GetCommandOptions(FieldInfo[] fieldsInfo, PropertyInfo[] propertiesInfo,
        object? instance);
}