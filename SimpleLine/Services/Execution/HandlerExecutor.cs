using SimpleLineLibrary.Services.Execution.Binding;
using SimpleLineLibrary.Services.Execution.Converting;
using SimpleLineLibrary.Services.Execution.Exceptions;
using SimpleLineLibrary.Services.Execution.Parsing;
using SimpleLineLibrary.Models;
using System.Reflection;

namespace SimpleLineLibrary.Services.Execution
{
    internal class CommandActionExecutor
    {
        private readonly CommandAction _action;

        public CommandActionExecutor(CommandAction action)
        {
            _action = action;
        }

        internal object? Execute(Queue<string> args, IReadOnlyDictionary<Type, Func<string, object?>> types)
        {
            try
            {
                var parser = new ExecutionDataParser();
                var exData = parser.Parse(args);

                if (exData.ArgCount < _action.Parameters.Count(x => x.IsRequired))
                {
                    throw new ArgumentException("Count of args less than count of required handler paramters");
                }
                if (exData.ArgCount > _action.Parameters.Count)
                {
                    throw new ArgumentException("Count of args bigger than count of handler parameters");
                }

                foreach (var i in exData.Keys)
                {
                    if (!_action.AvalibleKeys.Contains(i))
                    {
                        throw new UnknowKeyException(i, _action.AvalibleKeys);
                    }
                }

                var converter = new Converter(types);
                var valueBinder = new ValueBinder(converter);

                var bind = valueBinder.Bind(_action.Parameters, exData);

                return _action.Method(bind);
            }
            catch (TargetInvocationException ex)
            {
                throw new UserException(ex.InnerException!);
            }
            catch (Exception e)
            {
                throw new ExecutionException(e);
            }
        }
    }
}