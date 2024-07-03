using SimpleLineLibrary.Services.Execution.Exceptions;
using SimpleLineLibrary.Services.CommandFinding;
using SimpleLineLibrary.Services.InfoReading;
using SimpleLineLibrary.Services.Execution;
using SimpleLineLibrary.Services.CommandParsing;

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

                var commandParser = new CommandParser(config.ProgramName, config.InjectibleTypes);
                var root = commandParser.GetCommands(config.DefinedTypes);

                var commandFinder = new CommandFinder();
                var com = commandFinder.Find(qArgs, root);

                if (qArgs.Count > 0 && config.HelpKeys.Contains(qArgs.Peek()))
                {
                    var infoBuilder = new InfoReader();
                    var info = infoBuilder.GetInfo(com);
                    Console.WriteLine(info);
                    return null;
                }

                if(com.Handler == null)
                {
                    config.OnHandlerMissing?.Invoke(com.Uid);
                    return null;
                }

                var handlerExecutor = new HandlerExecutor(com.Handler); 
                var result = handlerExecutor.Execute(qArgs, config.ConvertibleTypes);

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