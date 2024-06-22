using SimpleLineLibrary.Setup;

namespace SimpleLineLibrary.Example.Commands
{
    [CommandDefinitions]
    public class FileCommand
    {
        [Command("read")]
        public void ReadFile(
            [CustomKeys("-p", "--path")] string path)
        {
            if (File.Exists(path))
            {
                var text = File.ReadAllText(path);

                Console.WriteLine(text);
            }
        }
    }
}
