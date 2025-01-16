using System.Reflection;
using simpleline.models.options;

namespace simpleline.services.registrar.options.actions;

internal abstract class ActionOptionRegistrarBase {
    public abstract Option[] GetActionOptions(ParameterInfo[] parametersInfo);
}