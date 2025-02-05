using simpleline.models.commands;
using simpleline.services.router.exceptions;

namespace simpleline.services.router;

internal abstract class RouterBase {
    public Command Route(IEnumerable<Command> commands, ref IEnumerable<Symbol> input) {
        try {
            return OnRoute(commands, (RouteInput)(input = new RouteInput(input)));
        }
        catch (Exception e) {
            throw new RouterException(e);
        }
    }

    protected abstract Command OnRoute(IEnumerable<Command> commands, RouteInput routeInput);
}