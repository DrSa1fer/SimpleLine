using simpleline.models;
using simpleline.models.commands;

namespace simpleline.services.routing;

internal abstract class RouterBase
{
    public abstract Command Route(Context context);
}