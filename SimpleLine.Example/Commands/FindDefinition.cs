using SimpleLineLibrary.Setup;

namespace SimpleLineLibrary.Example.Commands
{
    [CommandsDefinitions]
    public class FindDefinition
    {
        [Command("find")]
        public void Find(FindFilter filter, DataSize? dataSize = null)
        {
            System.Console.WriteLine(filter);
            System.Console.WriteLine(dataSize?.Count);
            System.Console.WriteLine(dataSize?.Multiplier);
        }
    }

    public enum FindFilter
    {
        All, NoAll
    }
    public class DataSize
    {
        public int Count;
        public int Multiplier;
    }
}