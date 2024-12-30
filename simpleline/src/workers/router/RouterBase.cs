using simpleline.models.commands;
using simpleline.services;

namespace simpleline.workers.router;

internal abstract class RouterBase
{
    public abstract Command Route(Context context);
}