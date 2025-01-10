using simpleline.models.commands;

namespace simpleline.services.router;

internal interface IRoute : ICommandAttribute {
    string Route { get; }
}