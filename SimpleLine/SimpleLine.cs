using SimpleLineLibrary.Services.Execution.Exceptions;
using SimpleLineLibrary.Services.TypeFinding;
using SimpleLineLibrary.Services.InfoReading;
using SimpleLineLibrary.Services.Execution;
using SimpleLineLibrary.Services.TypeParsing;

namespace SimpleLineLibrary
{
    public class SimpleLine
    {        
        private readonly Configuration _config;
        private readonly CommandFinder _commandFinder;
        private readonly InfoReader _infoBuilder;
        private readonly HandlerExecutor _handlerExecutor;
        private readonly CommandDefinitionsParser _definitionsParser;

        /// <summary>
        /// Launch Point 
        /// </summary>
        /// <param name="args">Input tokens</param>
        /// <returns></returns>
        public object? Run(IEnumerable<string> args)
        {
            try
            {
                _config.OnBeforeRun?.Invoke();

                if(!args.Any())
                {
                    _config.OnNoArguments?.Invoke();
                    return null;
                }
                
                var root = _definitionsParser.GetDefinitions(_config.DefinedTypes);
                
                var qArgs = new Queue<string>(args);
                
                if(qArgs.TryPeek(out string? a) && a == "list")
                {
                    foreach(var s in root.Subcommands)
                    {
                        Console.WriteLine(s.Key);
                    }
                    return null;
                }


                var com = _commandFinder.Find(qArgs, root);

                if (com == null)
                {
                    if(qArgs.TryPeek(out string? peek))
                    {
                        _config.OnCommandNotFound?.Invoke(peek);
                    }
                    return null;
                }

                if (qArgs.Count > 0 && _config.HelpKeys.Contains(qArgs.Peek()))
                {
                    var info = _infoBuilder.GetInfo(com);
                    Console.WriteLine(info);
                    return null;
                }

                if(com.Handler == null) 
                {
                    _config?.OnHandlerMissing?.Invoke(com.Uid);
                    return null;
                }

                var conTypes = _config.ConvertibleTypes;

                var result = _handlerExecutor.Execute(com.Handler, qArgs, conTypes);

                _config.OnAfterRun?.Invoke();

                return result;
            }
            catch(UserRuntimeException e)
            {
                _config.OnUserException?.Invoke(e);
                return null;
            }
            catch (Exception e)
            {
               _config.OnSimpleLineException?.Invoke(e);
                return null;
            }
        }

        private SimpleLine(Configuration config)
        {
            _config = config;

            _infoBuilder = new InfoReader(_config.ProgramName, _config.ProgramVersion);
            _definitionsParser = new CommandDefinitionsParser(_config.ContextOperator);
            _commandFinder = new CommandFinder(_config.InjectibleTypes);
            _handlerExecutor = new HandlerExecutor();
        }
        /// <summary>
        /// Build SimpleLine
        /// </summary>
        /// <param name="configuration">SimpleLine configuration</param>
        /// <returns></returns>
        public static SimpleLine Build(Configuration configuration)
        {
            return new SimpleLine(configuration);
        }
    }
}