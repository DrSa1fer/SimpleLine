using simpleline.models;

namespace simpleline.services.routing;

internal class Router : RouterBase
{
    public override Command Route(Context context)
    {
        var current = default(Command);
        
        var input = context.Route;

        var commands = context.Commands.Select(command => new
        {
            command, 
            attr = command
                .Attributes
                .OfType<IRouted>()
                .First()
        });

        for (var i = 0; i < input.Count; i++)
        {
            var symbol = input.Peek(i);

            var wi = i;
            commands = commands.Where(x => x.attr
                .Route[wi]
                .Equals(
                    symbol,
                    StringComparison.InvariantCultureIgnoreCase
                )
            );

            var tmp = commands
                .Select(x => x.command)
                .FirstOrDefault();

            if (tmp == null)
            {
                continue;
            }
            
            current = tmp;
            input.Take(i);
        }
        
        return current ?? throw new Exception("Command is missing");
    }
}