using simpleline.models;

namespace simpleline.services.routing;

internal class Router : RouterBase
{
    public override Command Route(Context context)
    {
        var input = context.Route;
        var result = default(Command);

        foreach (var command in context.Commands)
        {
            var attr = command
                .Attributes
                .OfType<IRouted>()
                .SingleOrDefault();

            if (attr == null)
                continue;

            return command;
        }

        return result ?? throw new Exception("Command is missing");
    }
}