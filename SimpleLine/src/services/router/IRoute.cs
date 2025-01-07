using simpleline.models.commands;

namespace simpleline.services.router;

internal interface IRoute : ICommandAttribute
{
    internal IReadOnlyList<string> Route { get; }
}