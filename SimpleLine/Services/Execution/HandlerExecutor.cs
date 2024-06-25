using SimpleLineLibrary.Services.Execution.Converting;
using SimpleLineLibrary.Services.Execution.Exceptions;
using SimpleLineLibrary.Models;
using System.Reflection;
using System.Collections;
using SimpleLineLibrary.Services.Execution.Binding;
using SimpleLineLibrary.Services.Execution.Parsing;

namespace SimpleLineLibrary.Services.Execution
{
    internal class HandlerExecutor
    {
        internal object? Execute(Handler handler, Queue<string> args, IReadOnlyDictionary<Type, Func<string, object?>> types)
        {            
            try
            {
                var parser = new ExecutionDataParser();
                var exData = parser.Parse(args);
                
                if(exData.ArgCount < handler.Parameters.Count(x => x.IsRequired))
                {
                    throw new ArgumentException("Count of args less than count of required handler paramters");
                }
                if(exData.ArgCount > handler.Parameters.Count)
                {
                    throw new ArgumentException("Count of args bigger than count of handler paramters");
                }
                foreach(var i in exData.Keys)
                {
                    if(!handler.AvalibleKeys.Contains(i))
                    {
                        throw new UnknowKeyException(i, handler.AvalibleKeys);
                    }
                }
                
                var converter = new Converter(types);                
                var bind = ValueBinder.Bind(handler.Parameters, exData, converter);
                
                return handler.Invoke(bind);
            }
            catch (TargetInvocationException ex)
            {
                throw new UserRuntimeException(ex.InnerException);
            }
        }        
    }
}