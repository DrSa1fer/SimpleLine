using SimpleLineLibrary.Services.Parsing.Arguments;
using SimpleLineLibrary.Services.Parsing.Tokens;
using SimpleLineLibrary.Services.Finding;
using SimpleLineLibrary.Services.Execution.Exceptions;
using SimpleLineLibrary.Services.Execution;
using SimpleLineLibrary.Services.BuildingInfo;

namespace SimpleLineLibrary
{
    public class SimpleLine
    {        
        private readonly Configuration _config;
        
        private readonly TokenParser _tokenParser;
        private readonly ArgumentParser _argumentParser;

        private readonly CommandFinder _commandFinder;
        private readonly InfoBuilder _infoBuilder;

        private readonly HandlerExecutor _handlerExecutor;

        private SimpleLine(Configuration config)
        {
            _config = config;

            _tokenParser = new TokenParser();
            _argumentParser = new ArgumentParser();
            
            _commandFinder = new CommandFinder();
            _handlerExecutor = new HandlerExecutor();
            
            _infoBuilder = new InfoBuilder(_config.ProgramName, _config.ProgramVersion);
        }

        /// <summary>
        /// Launch Point 
        /// </summary>
        /// <param name="args">Input tokens</param>
        /// <returns></returns>
        public object? Run(IEnumerable<string> args)
        {
            try
            {
                if(!args.Any())
                {
                    _config.OnNoArguments?.Invoke();
                    return null;
                }                

                var qArgs = new Queue<string>(args);
                var com = _commandFinder.Find(qArgs, _config.DefinedTypes);

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

                var parseArgs = _argumentParser.Parse(qArgs);
                var conTypes = _config.ConvertibleTypes;
                var execData = new ExecutionData(parseArgs);

                return _handlerExecutor.Execute(com.Handler, execData, conTypes);
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