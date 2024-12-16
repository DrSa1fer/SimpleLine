using simpleline.models;
using simpleline.models.commands;

namespace simpleline.services.routing;

public abstract class RouterBase
{
    public abstract Command? Route(Context context, Node root);
}