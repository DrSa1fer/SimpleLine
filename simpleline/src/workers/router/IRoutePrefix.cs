using simpleline.models.scopes;

namespace simpleline.workers.router;

internal interface IRoutePrefix : IScopeAttribute
{
    string Route { get; }
}