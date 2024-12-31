using simpleline.models.commands;

namespace simpleline.workers.router;

internal interface IRoute : ICommandAttribute
{
    internal IReadOnlyList<string> Route { get; }
}