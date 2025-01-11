using simpleline.models.commands;

namespace simpleline.services.router;

internal interface IRouteAttribute : ICommandAttribute {
    string Route { get; }
}