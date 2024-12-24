using simpleline.models.attributes;

namespace simpleline.services.router;

internal interface IRouted : ICommandAttribute
{
    IReadOnlyList<string> Route { get; }
}