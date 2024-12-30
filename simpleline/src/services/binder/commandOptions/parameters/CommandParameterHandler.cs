using simpleline.models.options;

namespace simpleline.services.binder.commandOptions.parameters;

public class CommandParameterHandler : CommandOptionHandlerBaseT<ICommandParameterAttribute>
{
    protected override void OnHandle(ICommandParameterAttribute attribute, CommandOption commandOption, Data data)
    {
        foreach (var key in attribute.Keys)
        {
            if (!data.TryGetValue(key, 1, out var value))
            {
                continue;
            }

            commandOption.SetValue(value);
        }

        throw new Exception();
    }
}