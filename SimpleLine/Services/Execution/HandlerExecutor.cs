using SimpleLineLibrary.Services.Execution.Converting;
using SimpleLineLibrary.Services.Execution.Exceptions;
using SimpleLineLibrary.Models;
using System.Reflection;
using System.Collections;
using SimpleLineLibrary.Services.Execution.Binding;

namespace SimpleLineLibrary.Services.Execution
{
    internal class HandlerExecutor
    {
        internal object? Execute(Handler handler, Queue<string> args, IReadOnlyDictionary<Type, Func<string, object?>> types)
        {            
            try
            {
                var exData = ExecutionData.Build(args);
                
                if(exData.ArgCount < handler.Parameters.Count(x => x.IsRequired))
                {
                    throw new ArgumentException("Count of args less than count of required handler paramters");
                }
                if(exData.ArgCount > handler.Parameters.Count)
                {
                    throw new ArgumentException("Count of args bigger than count of handler paramters");
                }
                if (!exData.Keys.All(handler.AvalibleKeys.Contains))
                {
                    throw new ArgumentException("Key is not supported of command" + string.Join(";", handler.AvalibleKeys));
                }
                
                var converter = new Converter(types);                
                var bind = ValueBinder.Bind(handler.Parameters, exData, converter);
                
                return handler.Invoke(bind);
            }
            catch (TargetInvocationException ex)
            {
                throw new UserRuntimeException(ex.InnerException);
            }            
            catch
            {
                throw;
            }
        }        
    }
}