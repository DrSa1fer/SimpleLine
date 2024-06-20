using SimpleLineLibrary.Extentions.Strings;

namespace SimpleLineLibrary.Models
{
    internal class Command
    {
        public string Uid
        {
            get
            {
                return _uid;
            }
        }
        public string Name
        {
            get
            {
                return _name;
            }
        }
        public string Description
        {
            get
            {
                return _description;
            }
        }

        public virtual IEnumerable<Command> Subcommands
        {
            get
            {
                return _subcommands;
            }
        }
        public Handler? Handler
        {
            get 
            {
                return _handler;
            }
        }

        private readonly string _uid;
        private readonly string _name;
        private readonly string _description;

        private readonly List<Command> _subcommands;
        private readonly Handler? _handler;

        public Command(string uid, string name, string desc, Handler? handler)             
        {
            uid.ThrowIfWrongTokenName();
            name.ThrowIfWrongTokenName();
            desc.ThrowIfWrongText();

            _uid = uid;
            _name = name; 
            _description = desc;
            _handler = handler;
            _subcommands = new();
        }

        public bool Is(string name)
        {
            return Uid.IsEqualsToken(name);
        }

        public bool ContainsSubcommand(Command subcommand)
        {
            return _subcommands.Contains(subcommand);
        }

        public void RegisterSubcommand(Command subcommand)        
        {
            if(_subcommands.Contains(subcommand))
            {
                throw new ArgumentException($"subcommand already added. [{subcommand.Name}]");
            }
            if(Equals(subcommand))
            {
                throw new ArgumentException("What are you doing, yopta?");
            }

            _subcommands.Add(subcommand);
        }     

        public override bool Equals(object? obj)
        {
            return obj is Command other
                && other.Uid.IsEqualsToken(this.Uid);
        }        
        public override int GetHashCode()
        {
            return HashCode.Combine(Uid, Name, Description);
        }
    }
}