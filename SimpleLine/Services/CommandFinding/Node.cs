using System.Reflection;

namespace SimpleLineLibrary.Services.CommandFinding
{
    internal class Node
    {
        public string Uid { get; }

        public Node? Parent { get; set; }
        public Dictionary<string, Node> Subcommands { get; }

        public TypeInfo? Type { get; set; }
        public MethodInfo? Method { get; set; }

        public Node(string uid)
        {
            Uid = uid;
            Subcommands = new();
        }
    }
}