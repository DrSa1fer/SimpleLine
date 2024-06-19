using SimpleLineLibrary.Setup;
using SimpleLineLibrary.Services.Parsing.Arguments;
using SimpleLineLibrary.Services.Parsing.Tokens;
using SimpleLineLibrary.Services.Finding;
using SimpleLineLibrary.Services.Execution.Exceptions;
using SimpleLineLibrary.Services.Execution;
using SimpleLineLibrary.Services.InfoRecieving;

namespace SimpleLineLibrary
{
    public class SimpleLine
    {        
        private readonly Configuration _config;
        
        private readonly ArgumentParser _argumentParser;
        private readonly TokenParser _tokenParser;

        private readonly CommandFinder _commandFinder;
        private readonly HandlerFinder _handlerFinder;
        private readonly InfoReceiver _infoReceiver;

        private readonly HandlerExecutor _handlerExecutor;

        private SimpleLine(Configuration config)
        {
            _config = config;

            _argumentParser = new ArgumentParser();
            _tokenParser = new TokenParser();
            
            _commandFinder = new CommandFinder();
            _handlerFinder = new HandlerFinder();

            _handlerExecutor = new HandlerExecutor(_config.Converter);
            
            _infoReceiver = new InfoReceiver(_config.ProgramName, _config.ProgramVersion);
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
                    _config.NoneArgsHandler?.Invoke();
                    return null;
                }

                var coms = _config.CommandProvider.GetCommands();

                var qArgs = new Queue<string>(args);
                var com = _commandFinder.Find(qArgs, coms);

                if (com == null)
                {
                    if(qArgs.TryPeek(out string? peek))
                    {
                        _config.CommandNotFound?.Invoke(peek);
                    }
                    return null;
                }

                if (qArgs.Count > 0 && _config.HelpKeys.Contains(qArgs.Peek()))
                {
                    var info = _infoReceiver.ReceiveFrom(com);
                    Console.WriteLine(info);
                    return null;
                }

                var han = _handlerFinder.Find(qArgs, com.Handlers);

                if (han == null)
                {
                    _config.HandlerNotFound?.Invoke(qArgs);
                    return null;
                }

                if (qArgs.Count > 0 && _config.HelpKeys.Contains(qArgs.Peek()))
                {
                    var info = _infoReceiver.ReceiveFrom(han);
                    //Console.WriteLine(info);
                    return null;
                }

                var parseArgs = _argumentParser.Parse(qArgs);
                var execData = new ExecutionData(parseArgs);

                return _handlerExecutor.Execute(han, execData);
            }
            catch(UserRuntimeException userEx)
            {
                throw userEx.InnerException!;                
            }
            catch (Exception ex)
            {
                _config.ExceptionHandler?.Invoke(ex);
                throw;
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