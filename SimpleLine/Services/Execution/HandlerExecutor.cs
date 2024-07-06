using SimpleLineLibrary.Services.Execution.Converting;
using SimpleLineLibrary.Services.Execution.Exceptions;
using SimpleLineLibrary.Services.Execution.Binding;
using SimpleLineLibrary.Services.Execution.Parsing;
using SimpleLineLibrary.Models;
using System.Reflection;

namespace SimpleLineLibrary.Services.Execution
{
    internal class HandlerExecutor
    {
        private readonly Handler _handler;

        public HandlerExecutor(Handler handler)
        {
            _handler = handler;
        }

        internal object? Execute(Queue<string> args, IReadOnlyDictionary<Type, Func<string, object?>> types)
        {            
            try
            {
                var parser = new ExecutionDataParser();
                var exData = parser.Parse(args);
                
                if(exData.ArgCount < _handler.Parameters.Count(x => x.IsRequired))
                {
                    throw new ArgumentException("Count of args less than count of required handler paramters");
                }
                if(exData.ArgCount > _handler.Parameters.Count)
                {
                    throw new ArgumentException("Count of args bigger than count of handler parameters");
                }

                foreach(var i in exData.Keys)
                {
                    if(!_handler.AvalibleKeys.Contains(i))
                    {
                        throw new UnknowKeyException(i, _handler.AvalibleKeys);
                    }
                }
                
                var converter = new Converter(types);
                var valueBinder = new ValueBinder();
                
                var bind = valueBinder.Bind(_handler.Parameters, exData, converter);
                
                return _handler.Invoke(bind);
            }
            catch (TargetInvocationException ex)
            {
                throw new UserException(ex.InnerException!);
            }
            catch(Exception e)
            {
                throw new ExecutionException(e);
            }
        }        
    }
}