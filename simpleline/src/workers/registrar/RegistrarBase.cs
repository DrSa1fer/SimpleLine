using System.Reflection;
using simpleline.models.commands;

namespace simpleline.workers.registrar;

public abstract class RegistrarBase
{
    public abstract IEnumerable<Command> Register(IEnumerable<TypeInfo> types);
}