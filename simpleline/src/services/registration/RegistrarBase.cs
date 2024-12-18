using System.Reflection;
using simpleline.models;
using simpleline.models.commands;

namespace simpleline.services.registration;

public abstract class RegistrarBase
{
    public abstract IEnumerable<Command> Register(IEnumerable<TypeInfo> types);
}