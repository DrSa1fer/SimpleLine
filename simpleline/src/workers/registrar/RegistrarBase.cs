using simpleline.models.commands;
using System.Reflection;

namespace simpleline.workers.registrar;

internal abstract class RegistrarBase
{
    public abstract Command[] Register(IEnumerable<Assembly> assemblies);
}