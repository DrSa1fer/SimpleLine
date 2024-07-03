namespace SimpleLineLibrary.Models
{
    internal class Command
    {
        public string Uid { get; }
        public string Description { get; set; }
        public string DocsLink { get; set; }

        public Command? Parent { get; set; }
        public Dictionary<string, Command> Children { get; set; }

        public Handler? Handler { get; set; }

        public Command(string uid)             
        {
            Uid  = uid;
            Parent = null;
            Children = new();

            Description = string.Empty;
            DocsLink = string.Empty;

            Handler = null;
        }  
    }
}