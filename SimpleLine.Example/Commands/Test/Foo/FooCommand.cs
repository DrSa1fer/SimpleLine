using SimpleLineLibrary.Setup;
using SimpleLineLibrary.Setup.Help;

namespace SimpleLineLibrary.Example.Commands.Test.Foo
{
    [Command("test foo")]
    [Description("foo command")]
    public class FooCommand
    {
        private readonly TextWriter _writer;

        public FooCommand(TextWriter writer) 
        {
            _writer = writer;
        }

        [CommandAction]
        public void Foo()
        {
            _writer.WriteLine("Foo!");
        }
    }
}
