using simpleline.configs;
using simpleline.models.commands;

namespace simpleline.services.helper;

internal abstract class HelperBase
{
    public abstract void Help(ApplicationConfig config, Command command);
}