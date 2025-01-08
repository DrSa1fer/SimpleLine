using simpleline.models.commands;
using simpleline.services.router.exceptions;

namespace simpleline.services.router;

internal abstract class RouterBase {
    public Command Route(ICollection<Command> commands, Input input) {
        try {
            return OnRoute(commands, new Route([]));
        }
        catch (Exception e) {
            throw new RouterException(e);
        }
    }

    protected abstract Command OnRoute(IEnumerable<Command> commands, Route route);
}