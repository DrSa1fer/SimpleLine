using simpleline.models.commands;

namespace simpleline.services.router;

internal class Router : RouterBase
{
    public override Command Route(Command[] commands, Input input)
    {
        var current = default(Command);

        var c = commands.Select(command => new
        {
            command,
            attr = command
                .Attributes
                .OfType<IRoute>()
                .First()
        });

        return current ?? commands.First(); //TODO
    }
}