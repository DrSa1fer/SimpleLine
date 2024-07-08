using SimpleLineLibrary.Extentions;

namespace SimpleLineLibrary.Models
{
    internal class Command
    {
        public string Uid { get; }

        public CommandAction? Action { get; set; }
        
        private readonly List<HelpBlock> _helpBlocks;

        public Command(string uid)             
        {
            Uid = uid;
            Action = null;

            _helpBlocks = new();
        }

        public void AddHelpBlock(HelpBlock block) => _helpBlocks.Add(block);        
        public IEnumerable<HelpBlock> GetHelpBlocks() => _helpBlocks;
    }
}