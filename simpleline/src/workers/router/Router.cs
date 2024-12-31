using simpleline.extensions;
using simpleline.models.commands;
using simpleline.models.scopes;

namespace simpleline.workers.router;

internal class Router : RouterBase
{
    public override Command Route(Input input, Scope[] scopes)
    {
        foreach (var scope in scopes)
        {
            var prefix = scope.Attributes
                .FirstOrDefault(x => x is IRoutePrefix) as IRoutePrefix;

            if (prefix != null)
            {
                var isPrefix = prefix.Route.IsPrefix([]);

                if (!isPrefix) continue;
            }
        }

        throw new NotImplementedException();
    }
}


//
// {
//     public override Command Run(IEnumerable<Command> c)
//     {
//         var current = default(Command);
//         
//
//         var commands = c.Select(command => new
//         {
//             command, 
//             attr = command
//                 .Attributes
//                 .OfType<IRouted>()
//                 .First()
//         });
//
//         for (var i = 0; i < input.Count; i++)
//         {
//             var symbol = input.Peek(i);
//
//             var wi = i;
//             commands = commands.Where(x => x.attr
//                 .Route[wi]
//                 .Equals(
//                     symbol,
//                     StringComparison.InvariantCultureIgnoreCase
//                 )
//             );
//
//             var tmp = commands
//                 .Select(x => x.command)
//                 .FirstOrDefault();
//
//             if (tmp == null)
//             {
//                 continue;
//             }
//             
//             current = tmp;
//             input.Take(i);
//         }
//         
//         return current ?? throw new Exception("Command is missing");
//     }
// }