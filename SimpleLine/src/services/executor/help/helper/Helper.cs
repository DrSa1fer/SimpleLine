using simpleline.external;
using simpleline.models.commands;

namespace simpleline.services.executor.help.helper;

internal class Helper(ApplicationMeta app) : HelperBase {
    public override string Help(Command command) {
        return "It s help of command";
    }
}