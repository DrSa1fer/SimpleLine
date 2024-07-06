using SimpleLineLibrary.Extentions;

namespace SimpleLineLibrary.Models
{
    internal class Command
    {
        public string Uid { get; }

        public Command? Parent { get; set; }
        public Dictionary<string, Command> Children { get; }

        public Handler? Handler { get; set; }
        
        private readonly List<HelpBlock> _helpBlocks;

        public Command(string uid)             
        {
            Uid  = uid;

            Parent = null;
            Children = new();
            
            Handler = null;

            _helpBlocks = new();
        }  

        public void AddHelpBlock(HelpBlock block)
        {
            _helpBlocks.Add(block);
        }
        public HelpBlock? GetHelpBlock(string header)
        {
            return _helpBlocks.FirstOrDefault(x => x.Header.IsEqualsToken(header));
        }
        public IEnumerable<HelpBlock> GetHelpBlocks(string header)
        {
            return _helpBlocks.Where(x => x.Header.IsEqualsToken(header));
        }
        public IEnumerable<HelpBlock> GetHelpBlocks()
        {
            return _helpBlocks;
        }
    }
}