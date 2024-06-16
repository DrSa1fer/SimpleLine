using SimpleLineLibrary.Models;
using SimpleLineLibrary.Models.Data;
using SimpleLineLibrary.Services.Invokation.Converting;

namespace SimpleLineLibrary.Services.Invokation
{
    internal class CategoryFilter
    {
        private readonly Func<string, Category?> _converter;

        public CategoryFilter(ConverterProvider converter)
        {
            _converter = converter.Convert<Category?>;
        }

        public IEnumerable<Command> Filter(Queue<string> args, IReadOnlyList<Command> commands)
        {
#if DEBUG
            var category = Category.Debug;

            if (args.Peek().StartsWith("@"))
            {
                var cat = args.Dequeue();
                
                var converted = _converter(cat);

                if(converted != null)
                {
                    category = (Category)converted;
                }
            }

           // return commands.Where(x => x.Category == category);
#else
            //return commands.Where(x => x.Category == Category.Release);
#endif
            return commands;
        }
    }
}
