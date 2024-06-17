using SimpleLineLibrary.Setup;

namespace SimpleLineLibrary.User.Commands
{
    [Command("file")]
    public class FileCommand
    {
        [Handler("--read")]
        public void ReadFile(
            [CustomKeys("-p", "--path")] string path)
        {
            if(File.Exists(path))
            {
                var text = File.ReadAllText(path);
                
                Console.WriteLine(text);
            }
        }
    }
}
