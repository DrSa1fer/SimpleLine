using simpleline.helpers;
using simpleline.models.commands;

namespace simpleline.services.router;

internal class Router : RouterBase {
    protected override Command OnRoute(IEnumerable<Command> commands, Route route) {
        var current = default(Command);
        var max = 0;

        foreach (var command in commands) {
            var attr = command.Attributes.OfType<IRoute>().First();

            if (!attr.Route.IsPrefix(route)) {
                continue;
            }

            if (attr.Route.Count < max) {
                continue;
            }

            current = command;
            max = attr.Route.Count;
        }

        if (current == null) {
            throw new NullReferenceException("Command was null.");
        }

        return current;
    }
}