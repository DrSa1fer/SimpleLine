using SimpleLineLibrary.Src.Exceptions;
using SimpleLineLibrary.Src.Exceptions.InputExceptions;

namespace SimpleLineLibrary.Src.Execution
{
    public sealed class InputData
    {
        private InputData(string n, List<string> l)
        {
            CommandName = n;
            _items = l;
        }

        public string CommandName { get; }
        public List<string> Items => new(_items);

        private readonly List<string> _items;

        public static InputData Make(string[] args)
        {
            try
            {
                var name = args[0];                
                var list = args.Length > 1 ? args[1..].ToList() : new();
                return new InputData(name, list);                
            }
            catch
            {
                throw new InvalidInputException();
            }            
        }
    }
}