using simpleline.models;
using simpleline.models.inputs;

namespace simpleline.services.binder.commandOptions.parameters;

public class ParameterHandler : CommandOptionHandlerBaseT<IParameterAttribute>
{
    protected override void OnHandle(IParameterAttribute attribute, CommandOption commandOption, Data data)
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