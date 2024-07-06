using SimpleLineLibrary.Services.CommandParsing.Exceptions;
using SimpleLineLibrary.Services.Execution.Exceptions;
using SimpleLineLibrary.Services.CommandFinding;
using SimpleLineLibrary.Services.CommandParsing;
using SimpleLineLibrary.Services.HelpReading;
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

                //Preparation
                var qArgs = new Queue<string>(args);               

                //Parse command from types
                var commandParser = new CommandParser(config.ProgramName, config.InjectibleTypes);
                var root = commandParser.GetCommands(config.DefinedTypes);

                //Find command from parse
                var commandFinder = new CommandFinder();
                var com = commandFinder.Find(qArgs, root);

                //Getting help if conditions are true
                if (qArgs.Count > 0 && config.HelpKeys.Contains(qArgs.Peek()))
                {
                    var helpReader = new HelpReader();
                    var text = helpReader.GetHelp(com);

                    config.OnGetHelp?.Invoke(text);
                    return null;
                }

                //Check handler
                if(com.Handler == null)
                {
                    config.OnImplementationMissing?.Invoke(com.Uid);
                    return null;
                }

                //Execute command handler
                var handlerExecutor = new HandlerExecutor(com.Handler); 
                var result = handlerExecutor.Execute(qArgs, config.ConvertibleTypes);

                config.OnAfterRun?.Invoke();

                return result;
            }
            catch(InitializationException e)
            {
                config.OnInitializationException?.Invoke(e);
                return null;
            }
            catch(UserException e)
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