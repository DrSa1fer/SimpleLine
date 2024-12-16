using simpleline.models;
using simpleline.models.commands;

namespace simpleline.services.routing;

public class Router : RouterBase
{
    public override Command? Route(Context context, Node root)
    {
        var input = context.RouteInput;
        var local = root;

        while (input.MoveNext())
        {
            var tmp = local.Next
                .OrderBy(node => ((string)node.Symbol).Length)
                .FirstOrDefault(node => node.Symbol == input.Current);

            if (tmp == null)
                break;

            local = tmp;
        }

        return local.Command;
    }
}