namespace SimpleLineLibrary.Models
{
    internal class Command
    {
        public string Uid { get; }

        public CommandAction? ChachedAction => _chachedAction ??= ActionFunc?.Invoke();
        public List<HelpBlock> ChachedHelpBlocks => (_chachedHelp ??= HelpBlocksFunc?.Invoke()) ?? new();
        
        public Func<CommandAction?>? ActionFunc { get; set; }
        public Func<List<HelpBlock>?>? HelpBlocksFunc { get; set; }

        private CommandAction? _chachedAction;
        private List<HelpBlock>? _chachedHelp;

        public Command(string uid)
        {
            Uid = uid;
        }
    }
}