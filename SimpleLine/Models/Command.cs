using SimpleLineLibrary.Extentions;

namespace SimpleLineLibrary.Models
{
    internal class Command
    {
        public string Uid { get; }

        public Command? Parent { get; set; }
        public CommandAction? Action { get; set; }
        
        private readonly Dictionary<string, Command> _children;
        private readonly List<HelpBlock> _helpBlocks;

        public Command(string uid)             
        {
            Uid  = uid;

            Parent = null;
            Action = null;

            _children = new();
            _helpBlocks = new();
        }

        public void AddHelpBlock(HelpBlock block) => _helpBlocks.Add(block);
        public HelpBlock? GetHelpBlock(string header) => _helpBlocks.FirstOrDefault(x => x.Header.IsEqualsToken(header));
        
        public IEnumerable<HelpBlock> GetHelpBlocks(string header) => _helpBlocks.Where(x => x.Header.IsEqualsToken(header));
        public IEnumerable<HelpBlock> GetHelpBlocks() => _helpBlocks;
    }
}