using SimpleLineLibrary.Setup.Help;
using SimpleLineLibrary.Setup;

namespace SimpleLineLibrary.Example.Commands
{
    [CommandsDefinitions("file")]
    [Description("Group of file interaction commands")]
    [DocsLink("https://github.com/")]
    [HelpBlock("Remark", "Some changes in behavior this commands", -1)]
    [HelpBlock("Feature", "new feature", -1)]
    public class FileCommands
    {
        [Command("read file")]
        [Description("desc")]
        public static void ReadFile(FileInfo f)
        {
            if(!f.Exists)
            {
                throw new Exception("File no exists");
            }

            using var tr = f.OpenText();

            Console.WriteLine(tr.ReadToEnd());
        }

        [Command("test1")]
        public static void ReadFile1(FileInfo f)
        {
            if(!f.Exists)
            {
                throw new Exception("File no exists");
            }

            using var tr = f.OpenText();

            Console.WriteLine(tr.ReadToEnd());
        }
    }
}