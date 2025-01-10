using simpleline.configs;
using simpleline.models.commands;

namespace simpleline.services.executor.help.helper;

internal class Helper(HelpConfig conf, ConsoleFacade console) : HelperBase {
    public override void Help(Command command) {
        console.Out.WriteLine(conf.Program);
        console.Out.WriteLine(conf.Version);
        console.Out.WriteLine(command.Attributes.OfType<IHelpRoute>().First().Route);
    }
}