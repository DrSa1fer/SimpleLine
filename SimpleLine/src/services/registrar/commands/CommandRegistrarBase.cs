using System.Reflection;
using simpleline.models.commands;

namespace simpleline.services.registrar.commands;

internal abstract class CommandRegistrarBase {
    public abstract Command[] GetCommands(Assembly assembly);
}