using simpleline.exmodels;
using simpleline.models.commands;

namespace simpleline.services.executor.help.helper;

internal class Helper(ApplicationInfo conf) : HelperBase {
    public override string Help(Command command) {
        return "It s help of command";
    }
}