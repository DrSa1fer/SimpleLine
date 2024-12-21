using simpleline.models.attributes;

namespace simpleline.services.routing;

internal interface IRouted : ICommandAttribute
{
    IEnumerable<string> Route { get; }
}