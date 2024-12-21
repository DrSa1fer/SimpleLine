using System.Reflection;
using simpleline.models;

namespace simpleline.registrars;

public abstract class RegistrarBase
{
    public abstract IEnumerable<Command> Register(IEnumerable<TypeInfo> types);
}