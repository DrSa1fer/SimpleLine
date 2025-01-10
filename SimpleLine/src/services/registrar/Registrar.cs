using System.Reflection;
using simpleline.models.commands;
using simpleline.services.registrar.commands;

namespace simpleline.services.registrar;

internal class Registrar(CommandRegistrarBase commandRegistrar) : RegistrarBase {
    protected override Command[] OnRegister(IEnumerable<Assembly> assemblies) {
        return assemblies
            .Aggregate(
                Enumerable.Empty<Command>(),
                (current, assembly) => current.Concat(commandRegistrar.GetCommands(assembly))
            )
            .ToArray();
    }
}