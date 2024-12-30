using simpleline.models.commands;

namespace simpleline.workers.router;

internal interface IRouted : ICommandAttribute
{
    IReadOnlyList<string> Route { get; }
}