using System.Reflection;
using simpleline.models.scopes;

namespace simpleline.workers.registrar;

internal abstract class RegistrarBase
{
    public abstract Scope[] Register(IEnumerable<Assembly> assemblies);
}