using simpleline.models.commands;

namespace simpleline.workers.router;

internal interface IRoute : ICommandAttribute
{
    string Route { get; }
}