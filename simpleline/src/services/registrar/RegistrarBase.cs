using System.Reflection;
using simpleline.models;

namespace simpleline.services.registrar;

public abstract class RegistrarBase
{
    public abstract IEnumerable<Command> Register(IEnumerable<TypeInfo> types);
}