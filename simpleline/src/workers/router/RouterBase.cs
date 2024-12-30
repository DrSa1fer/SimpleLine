using System.Reflection;
using simpleline.models.commands;
using simpleline.models.scopes;

namespace simpleline.workers.router;

internal abstract class RouterBase
{
    public abstract Command Route(Scope[] scopes);
}