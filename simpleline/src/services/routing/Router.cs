using simpleline.models;
using simpleline.models.commands;

namespace simpleline.services.routing;

internal class Router : RouterBase
{
    public override Command Route(Context context, IEnumerable<Command> commands)
    {
        var input = context.Route;
        var result = default(Command);

        foreach (var command in commands)
        {
            var attr = command
                .Attributes
                .OfType<IRouted>()
                .SingleOrDefault();
            
            if(attr == null)
                continue;
            
            
        }
        
        return result ?? throw new Exception("Command is missing");
    }
}