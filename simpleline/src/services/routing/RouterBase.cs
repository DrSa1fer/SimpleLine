using System.Reflection;
using simpleline.models;

namespace simpleline.services.routing;

public abstract class RouterBase
{
    public abstract Type? Route(Context context, Node root);
}