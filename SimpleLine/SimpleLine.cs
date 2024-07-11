using SimpleLineLibrary.Services.CommandFinding;
using SimpleLineLibrary.Services.CommandParsing;
using SimpleLineLibrary.Services.CommandParsing.Exceptions;
using SimpleLineLibrary.Services.Execution;
using SimpleLineLibrary.Services.Execution.Exceptions;
using SimpleLineLibrary.Services.HelpReading;
using SimpleLineLibrary.Services.SetupValidation;

namespace SimpleLineLibrary
{
    /// <summary>
    /// Main class to using SimpleLineLibrary
    /// </summary>
    public static class SimpleLine
    {
        /// <summary>
        /// Launch Point 
        /// </summary>
        /// <param name="args">Input tokens</param>
        /// <param name="conf">Configuration of SimpleLine</param>
        /// <param name="validate">Use validate of setup. Use false only you know all data in attributes is valid. Need to make execution a few faster</param>
        /// <returns>Return value of executed command</returns>
        public static object? Run(IEnumerable<string> args, Configuration conf, bool validate = true)
        {
            try
            {
                conf.OnBeforeRun?.Invoke();

                if (conf == null)
                {
                    throw new ArgumentNullException(nameof(conf));
                }

                if (validate)
                {
                    var sv = new SetupValidator();
                    var ex = sv.Validate(conf.DefinedTypes);

                    if (ex.Any())
                    {
                        foreach (var e in ex)
                        {
                            conf.OnInitializationException?.Invoke(e);
                        }
                        return null;
                    }
                }

                //Preparation
                var qArgs = new Queue<string>(args);

                //Parse command from types
                var commandParser = new CommandParser(conf.InjectibleTypes);
                var root = commandParser.GetCommands(conf.DefinedTypes);

                //Find command from parse
                var commandFinder = new CommandFinder();
                var com = commandFinder.Find(qArgs, root);

                if (com == null)
                {
                    var token = qArgs.Count > 0 ? qArgs.Peek() : string.Empty;

                    conf.OnCommandMissing?.Invoke(token);
                    return null;
                }

                //Getting help if conditions are true
                if (qArgs.Count > 0 && conf.HelpKeys.Contains(qArgs.Peek()))
                {
                    var helpReader = new HelpReader();
                    var text = helpReader.GetHelp(com.ChachedHelpBlocks);

                    conf.OnGetHelp?.Invoke(text);
                    return null;
                }

                //Check handler
                if (com.ChachedAction == null)
                {
                    conf.OnCommandActionMissing?.Invoke(com.Uid);
                    return null;
                }

                //Execute command handler
                var handlerExecutor = new CommandActionExecutor(com.ChachedAction);
                var result = handlerExecutor.Execute(qArgs, conf.ConvertibleTypes);

                conf.OnAfterRun?.Invoke();

                return result;
            }
            catch (InitializationException e)
            {
                conf.OnInitializationException?.Invoke(e);
                return null;
            }
            catch (UserException e)
            {
                conf.OnUserException?.Invoke(e);
                return null;
            }
            catch (ExecutionException e)
            {
                conf.OnExecutionException?.Invoke(e);
                return null;
            }
            catch (Exception e)
            {
                conf.OnSimpleLineException?.Invoke(e);
                return null;
            }
        }
    }
}