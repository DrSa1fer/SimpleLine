using System.Reflection;
using simpleline.configs;
using simpleline.models.commands;
using simpleline.services;
using simpleline.workers;
using simpleline.workers.executor;
using simpleline.workers.registrar;
using simpleline.workers.router;

namespace simpleline;

public static class SimpleLine
{
    public static void Run(IEnumerable<string> input)
    {
        var assembly = Assembly
            .GetCallingAssembly();
        var lInput = new Input(input);
        
        var registrar = new Registrar();
        var commands = 
            registrar.Register([assembly]);
        
        var router = new Router();
        var command = 
            router.Route(commands, lInput);
        
        var ctx = new Context(new ApplicationConfig(), command, new Data(lInput));
        
        var executor = new Executor();
        executor.Execute(ctx);
    }
}