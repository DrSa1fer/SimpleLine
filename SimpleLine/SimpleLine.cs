using SimpleLineLibrary.Services.Invokation.Finding;
using SimpleLineLibrary.Services.Invokation.Execution;
using SimpleLineLibrary.Services.Parsing;
using SimpleLineLibrary.Setup;
using System.Reflection;
using SimpleLineLibrary.Exceptions;
using SimpleLineLibrary.Services.Invokation.Execution.Exceptions;
using SimpleLineLibrary.Setup.Exceptions;
using SimpleLineLibrary.Services.Invokation.Converting;

namespace SimpleLineLibrary
{
    public class SimpleLine
    {        
        private readonly Configuration _config;
        
        private readonly ArgumentParser _argumentParser;
        private readonly TokenParser _tokenParser;

        private readonly CommandProvider _commandProvider;

        private readonly CommandFinder _commandFinder;
        private readonly HandlerFinder _handlerFinder;

        private readonly HandlerExecutor _handlerExecutor;

        public SimpleLine(Configuration config)
        {
            _config = config;

            _commandProvider = new CommandProvider(new HashSet<string>());

            _argumentParser = new ArgumentParser();
            _tokenParser= new TokenParser();
            
            _commandFinder = new CommandFinder();
            _handlerFinder = new HandlerFinder();

            var cp = new ConverterProvider();

            cp.RegisterConverter(new TypeConverter<string>(x => x));
            cp.RegisterConverter(new TypeConverter<int>(int.Parse));

            _handlerExecutor = new HandlerExecutor(cp);
        }

        
        public object? Run(IReadOnlyList<string> args, params TypeInfo[] ts)
        {
            try
            {
                if(args.Count == 0)
                {
                    _config.NoneArgsHandler?.Invoke();
                    return null;
                }
                var qArgs = new Queue<string>(args);

                var commands = _commandProvider.FindCommands(ts);

                var com = _commandFinder.Find(qArgs, commands);

                if (com == null)
                {
                    _config.CommandNotFound?.Invoke(qArgs.Peek());
                    return null;
                }

                var han = _handlerFinder.Find(qArgs, com.Handlers);

                if (han == null)
                {
                    _config.HandlerNotFound?.Invoke(qArgs.ToList());
                    return null;
                }

                var parseArgs = _argumentParser.Parse(qArgs);
                var execData = new ExecutionData(parseArgs);

                return _handlerExecutor.Execute(han, execData);
            }
            catch(SetupException setupEx)
            {
                throw;// new Exception(setupEx.Message);
            }
            catch(UserRuntimeException userEx)
            {
                throw;// userEx.UserException;
            }
            catch(SimpleLineException simpEx)
            {                
                throw; //To do
            }
            catch (Exception ex)
            {
                _config.ExceptionHandler?.Invoke(ex);
                throw;// (ex as UserRuntimeException)!.UserException;
            }
        }

        public void Run(string input)
        {
            
        }
    }
}