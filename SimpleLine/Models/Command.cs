using SimpleLineLibrary.Extensions;

namespace SimpleLineLibrary.Models
{
    internal class Command : BaseEntity
    {              
        public virtual IEnumerable<Command> Subcommands
        {
            get
            {
                return _subcommands;
            }
        }

        public virtual IEnumerable<Handler> Handlers
        {
            get 
            {
                return _handlers;
            }
        }

        public string Uid
        {
            get
            {
                return Name;
            }
        }

        private readonly List<Command> _subcommands;
        private readonly List<Handler> _handlers;

        public Command(string uid, string name, string desc, bool @throw) 
            : base(uid, desc, @throw, @throw)
        {
            _handlers = new();
            _subcommands = new();
        }

        public bool Is(string name)
        {
            return Uid.IsEqualsTokenName(name);
        }

        public void RegisterSubcommand(Command subcommand)        
        {
            if(_subcommands.Contains(subcommand))
            {
                throw new Exceptions.ArgumentException($"subcommand already added. [{subcommand.Name}]");
            }
            if(Equals(subcommand))
            {
                throw new Exceptions.ArgumentException("What are you doing, yopta?");
            }

            _subcommands.Add(subcommand);
        }
        
        public void RegisterHandler(Handler handler)
        {
            if(_handlers.Contains(handler))
            {
                throw new Exceptions.ArgumentException("handler already added");
            }

            _handlers.Add(handler);
        }

        public override bool Equals(object? obj)
        {
            return obj is Command other
                && other.Uid.IsEqualsTokenName(this.Uid);
        }        
        public override int GetHashCode()
        {
            return HashCode.Combine(Uid, Name, Description);
        }
    }
}