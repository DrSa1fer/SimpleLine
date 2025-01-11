using System.Reflection;
using simpleline.models.commands;
using simpleline.services.registrar.actions;
using simpleline.services.registrar.options.commands;

namespace simpleline.services.registrar.commands;

internal class CommandRegistrar(
    ActionRegistrarBase actionRegistrar,
    CommandOptionRegistrarBase optionRegistrar
) : CommandRegistrarBase {
    public override Command[] GetCommands(Assembly assembly) {
        var tArr = Filter.Types(assembly.DefinedTypes).ToArray();
        var cArr = new Command[tArr.Length];

        for (var i = 0; i < cArr.Length; i++) {
            var attrs = tArr[i]
                .GetCustomAttributes()
                .OfType<ICommandAttribute>()
                .ToList();

            var properties = tArr[i].GetProperties();
            var methods = tArr[i].GetMethods();
            var fields = tArr[i].GetFields();

            var instance = Activator.CreateInstance(tArr[i]);
            var actions = actionRegistrar.GetActions(methods, instance);
            var options = optionRegistrar.GetCommandOptions(fields, properties, instance);

            cArr[i] = new Command(attrs, actions, options);
        }

        return cArr;
    }
}