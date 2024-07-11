namespace SimpleLineLibrary.Models
{
    internal class CommandNode
    {
        public string Uid { get; }
        public Command? Command { get; set; }
        public CommandNode? Parent { get; set; }
        public Dictionary<string, CommandNode> Children { get; } = new();

        public CommandNode(string uid)
        {
            Uid = uid;
        }
    }
}