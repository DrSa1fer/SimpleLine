namespace simpleline.services.router;

internal class RouteInput(IEnumerable<Symbol> input) : Queue<Symbol>(input);