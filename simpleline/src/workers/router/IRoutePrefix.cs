using simpleline.models.scopes;

namespace simpleline.workers.router;

internal interface IRoutePrefix : IScopeAttribute
{
    IReadOnlyList<string> Route { get; }
}