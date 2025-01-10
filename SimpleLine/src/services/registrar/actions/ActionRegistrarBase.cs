using System.Reflection;
using Action = simpleline.models.actions.Action;

namespace simpleline.services.registrar.actions;

internal abstract class ActionRegistrarBase {
    public abstract Action[] GetActions(MethodInfo[] methodsInfo, object? instance);
}