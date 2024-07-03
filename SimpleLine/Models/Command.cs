namespace SimpleLineLibrary.Models
{
    internal class Command
    {
        public string Uid { get; }
        public List<HelpBlock> HelpBlocks { get; }

        public Command? Parent { get; set; }
        public Dictionary<string, Command> Children { get; }

        public Handler? Handler { get; set; }

        public Command(string uid)             
        {
            Uid  = uid;
            HelpBlocks = new();

            Parent = null;
            Children = new();
            
            Handler = null;
        }  
    }
}