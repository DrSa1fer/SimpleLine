using simpleline.helpers;
using simpleline.models.commands;

namespace simpleline.services.router;

internal class Router : RouterBase {
    private record Candidate(Command Command, string[] Route);

    protected override Command OnRoute(IEnumerable<Command> commands, Route route) {
        var candidates = new List<Candidate>();

        foreach (var command in commands) {
            var attr = command.Attributes.OfType<IRouteAttribute>().FirstOrDefault();
            if (attr == null) {
                continue;
            }

            var r = attr.Route.Split();
            candidates.Add(new Candidate(command, r));
        }

        for (var seek = 0; route.TryPeek(out var value); seek++) {
            var iValue = value;
            var iSeek = seek;

            var t = candidates
                .Where(current => current.Route.Length > iSeek)
                .Where(current => current.Route[iSeek].HEquals(iValue))
                .ToList();

            if (t.Count == 0) {
                var f = candidates
                    .FirstOrDefault(x => x.Route.Length == iSeek - 1);

                if (iSeek == 0) {
                    f ??= candidates
                        .FirstOrDefault(x => x.Route.Length == 0);
                }

                if (f != null) {
                    return f.Command;
                }

                break;
            }

            _ = route.Take();
            if (t.Count == 1) {
                if (t[0].Route.Length == iSeek + 1) {
                    return t[0].Command;
                }
            }

            candidates = t;
        }

        throw new Exception("Command not found");
    }
}