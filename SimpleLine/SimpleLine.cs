using SimpleLineLibrary.Services.Execution.Exceptions;
using SimpleLineLibrary.Services.CommandFinding;
using SimpleLineLibrary.Services.InfoReading;
using SimpleLineLibrary.Services.Execution;

namespace SimpleLineLibrary
{
    public static class SimpleLine
    {        
        /// <summary>
        /// Launch Point 
        /// </summary>
        /// <param name="args">Input tokens</param>
        /// <returns></returns>
        public static object? Run(IEnumerable<string> args, Configuration config)
        {
            try
            {
                config.OnBeforeRun?.Invoke();

                var qArgs = new Queue<string>(args);
                var commandFinder = new CommandFinder(config.InjectibleTypes, config.ContextOperator);
                var com = commandFinder.Find(qArgs, config.DefinedTypes);

                if (com == null)
                {
                    if(qArgs.TryPeek(out string? peek))
                    {
                        config.OnCommandNotFound?.Invoke(peek);
                    }
                    return null;
                }

                if (qArgs.Count > 0 && config.HelpKeys.Contains(qArgs.Peek()))
                {
                    var infoBuilder = new InfoReader(config.ProgramName, config.ProgramVersion);
                    var info = infoBuilder.GetInfo(com);
                    Console.WriteLine(info);
                    return null;
                }

                if(com.Handler == null) 
                {
                    config?.OnHandlerMissing?.Invoke(com.Uid);
                    return null;
                }

                var handlerExecutor = new HandlerExecutor(com.Handler); 
                var conTypes = config.ConvertibleTypes;

                var result = handlerExecutor.Execute(qArgs, conTypes);

                config.OnAfterRun?.Invoke();

                return result;
            }
            catch(UserRuntimeException e)
            {
                config.OnUserException?.Invoke(e);
                return null;
            }
            catch (Exception e)
            {
                config.OnSimpleLineException?.Invoke(e);
                return null;
            }
        }
    }
}