using simpleline.models;

namespace simpleline.services.router;

internal abstract class RouterBase
{
    public abstract Command Route(Context context);
}