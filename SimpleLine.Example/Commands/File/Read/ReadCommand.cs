using SimpleLineLibrary.Setup.Help;
using SimpleLineLibrary.Setup;

namespace SimpleLineLibrary.Example.Commands.File.Read
{
    [Command("file read")]
    [HelpBlock("Remark", "Some changes in behavior this commands", -1)]
    [HelpBlock("Feature", "new feature", -1)]
    [Description("Group of file interaction commands")]
    [DocsLink("https://github.com/")]
    public class ReadCommand
    {
        private readonly TextWriter _writer;

        public ReadCommand(TextWriter writer)
        {
            _writer = writer;
        }

        [CommandAction]
        public void Read(FileInfo f)
        {
            if (!f.Exists)
            {
                _writer.WriteLine("File no exists");
            }

            using var tr = f.OpenText();

            _writer.WriteLine(tr.ReadToEnd());
        }
    }
}