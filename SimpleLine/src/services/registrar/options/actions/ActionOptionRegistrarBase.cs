using System.Reflection;
using simpleline.models.options.actions;

namespace simpleline.services.registrar.options.actions;

internal abstract class ActionOptionRegistrarBase {
    public abstract ActionOption[] GetActionOptions(ParameterInfo[] parametersInfo, object?[] sync);
}