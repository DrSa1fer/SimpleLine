using System.Reflection;
using simpleline.models.commands;
using simpleline.services.registrar.exceptions;

namespace simpleline.services.registrar;

internal abstract class RegistrarBase {
    public Command[] Register(IEnumerable<TypeInfo> assemblies) {
        try {
            return OnRegister(assemblies);
        }
        catch (Exception e) {
            throw new RegistrarException(e);
        }
    }

    protected abstract Command[] OnRegister(IEnumerable<TypeInfo> types);
}