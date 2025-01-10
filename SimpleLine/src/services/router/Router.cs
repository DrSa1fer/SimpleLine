using simpleline.helpers;
using simpleline.models.commands;

namespace simpleline.services.router;

internal class Router : RouterBase {
    private readonly record struct Candidate(Command Command, string[] Route);

    protected override Command OnRoute(IEnumerable<Command> commands, Route route) {
        var candidates = new List<Candidate>();

        foreach (var command in commands) {
            var attr = command.Attributes.OfType<IRoute>().FirstOrDefault();
            if (attr == null) {
                continue;
            }
            var r = attr.Route.Split();
            candidates.Add(new Candidate(command, r));
        }

        var exclude = new HashSet<int>();
        for(var seek = 0; route.TryPeek(out var value) && candidates.Count > 0; seek++) {
            for (var i = 0; i < candidates.Count; i++) {
                var current = candidates[i];

                if (current.Route.Length <= seek) {
                    exclude.Add(i);
                }
                else if (!current.Route[seek].HEquals(value)) {
                    exclude.Add(i);
                }

                if (candidates.Count != 1) {
                    continue;
                }

                _ = route.Take();
                return current.Command;
            }

            foreach (var ex in exclude) {
                candidates.RemoveAt(ex);
            }

            exclude.Clear();
            _ = route.Take();
        }

        throw new Exception("Command not found");
    }
}