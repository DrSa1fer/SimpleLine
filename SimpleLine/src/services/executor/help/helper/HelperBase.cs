using simpleline.configs;
using simpleline.models.commands;

namespace simpleline.services.executor.help.helper;

internal abstract class HelperBase
{
    public abstract void Help(HelperConfig config, Command command);
}