using simpleline.models.commands;

namespace simpleline.services.routing;

internal interface IRouted : ICommandAttribute
{
    IEnumerable<string> Route { get; }
}