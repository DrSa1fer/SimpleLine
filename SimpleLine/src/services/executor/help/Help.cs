using simpleline.models.commands;

namespace simpleline.services.executor.help;

internal class Help(IServiceProvider provider) : Case
{
    public override bool Is(Data data)
    {
        throw new NotImplementedException();
    }

    public override void Invoke(Command command, Data data)
    {
        throw new NotImplementedException();
    }
}