using System.Reflection;
using simpleline.models.commands;

namespace simpleline.services.registrar;

internal abstract class RegistrarBase
{
    public abstract Command[] Register(IEnumerable<Assembly> assemblies);
}