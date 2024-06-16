using SimpleLineLibrary.Setup;

namespace SimpleLineLibrary.User.Commands
{
    [Command("file")]
    public class FileCommand
    {
        private StreamWriter? _output;

        [Inject]
        public void Inject(StreamWriter output)
        {
            _output = output;
        }

        [Handler("--read")]
        public void ReadFile(string path)
        {
            if(File.Exists(path))
            {
                var text = File.ReadAllText(path);
                
                Console.WriteLine(text);
            }
        }
    }
}
