using SimpleLineLibrary.Setup;
using System.Reflection;
using SimpleLineLibrary.Exceptions;
using SimpleLineLibrary.Setup.Exceptions;
using SimpleLineLibrary.Services.Parsing.Arguments;
using SimpleLineLibrary.Services.Parsing.Tokens;
using SimpleLineLibrary.Services.Finding;
using SimpleLineLibrary.Services.Execution.Exceptions;
using SimpleLineLibrary.Services.Execution;
using SimpleLineLibrary.Services.Converting;
using SimpleLineLibrary.Services.Exceptions;
using SimpleLineLibrary.Extensions;
using SimpleLineLibrary.Services.InfoDisplay;

namespace SimpleLineLibrary
{
    public class SimpleLine
    {        
        private readonly Configuration _config;
        
        private readonly ArgumentsParser _argumentParser;
        private readonly TokensParser _tokenParser;

        private readonly CommandProvider _commandProvider;

        private readonly CommandFinder _commandFinder;
        private readonly HandlerFinder _handlerFinder;
        private readonly InfoDisplayer _infoDisplayer;

        private readonly HandlerExecutor _handlerExecutor;

        public SimpleLine(Configuration config)
        {
            _config = config;

            _commandProvider = new CommandProvider(new HashSet<string>());

            _argumentParser = new ArgumentsParser();
            _tokenParser= new TokensParser();
            
            _commandFinder = new CommandFinder();
            _handlerFinder = new HandlerFinder();
            _infoDisplayer = new InfoDisplayer(_config.HelpKeys, "simpleline.dll", "0.01");

            var cp = new ConverterProvider();

            cp.RegisterTypeConverter(x => x);
            cp.RegisterTypeConverter(int.Parse);
            cp.RegisterTypeConverter(x => x.IsEqualsTokenName("1"));

            _handlerExecutor = new HandlerExecutor(cp);
        }

        
        public object? Run(ICollection<string> args, Assembly assembly)
        {
            try
            {
                if(args.Count == 0)
                {
                    _config.NoneArgsHandler?.Invoke();
                    return null;
                }

                var qArgs = new Queue<string>(args);
                var coms = _commandProvider.FindCommands(assembly.DefinedTypes);
                var com = _commandFinder.Find(qArgs, coms);

                if (com == null)
                {
                    _config.CommandNotFound?.Invoke(qArgs.Peek());
                    return null;
                }

                if (_config.HelpKeys.Contains(qArgs.Peek()))
                {
                    var info = _infoDisplayer.GetInfo(com);
                    Console.WriteLine(info);
                    return null;
                }

                var han = _handlerFinder.Find(qArgs, com.Handlers);

                if (han == null)
                {
                    _config.HandlerNotFound?.Invoke(qArgs.ToList());
                    return null;
                }

                if (_config.HelpKeys.Contains(qArgs.Peek()))
                {
                    var info = _infoDisplayer.GetInfo(han);
                    Console.WriteLine(info);
                    return null;
                }

                var parseArgs = _argumentParser.Parse(qArgs);
                var execData = new ExecutionData(parseArgs);

                return _handlerExecutor.Execute(han, execData);
            }
            catch(SetupException setupEx)
            {
                throw setupEx;
            }
            catch(UserRuntimeException userEx)
            {
                throw userEx.InnerException!;
            }
            catch (ServiceException serviceEx)
            {
                throw serviceEx;
            }
            catch(SimpleLineException simpEx)
            {                
                throw simpEx;
            }
            catch (Exception ex)
            {
                _config.ExceptionHandler?.Invoke(ex);
                throw;
            }
        }

        public void Run(string input)
        {
            
        }
    }
}