using simpleline.helpers;
using simpleline.models.commands;
using FormatException = simpleline.services.router.exceptions.FormatException;

namespace simpleline.services.router;

internal class Router : RouterBase {
    private record Candidate(Command Command, string[] Route);

    protected override Command OnRoute(IEnumerable<Command> commands, RouteInput routeInput) {
        return commands.First();
        
        var candidates = new List<Candidate>();
        foreach (var command in commands) {
            var attr = command.Attributes.OfType<IRouteAttribute>().FirstOrDefault();
            if (attr == null) {
                continue;
            }

            var r = attr.Route.Split();

            foreach (var tmp in r) {
                if (tmp.Length <= 0 || !char.IsLetter(tmp[0])) {
                    throw new FormatException(attr.Route, tmp);
                }

                if (tmp.Length == 1) {
                    continue;
                }

                if (tmp[1..].All(char.IsLetterOrDigit)) {
                    continue;
                }

                throw new FormatException(attr.Route, tmp);
            }
            
            candidates.Add(new Candidate(command, r));
        }

        for (var seek = 0; routeInput.TryPeek(out var value); seek++) {
            var iValue = value.Value;
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

            _ = routeInput.Dequeue();
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