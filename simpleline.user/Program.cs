using System.Reflection;
using simpleline.configs;
using simpleline.models;
using simpleline.models.inputs;
using simpleline.services.registration;

// SimpleLine.Run(args);

var res = new Registrar()
    .Register(new Context(new ApplicationConfig { DefinedTypes = Assembly.GetEntryAssembly()!.DefinedTypes }, new Input([])));


foreach (var r in res)
{
    foreach(var a in r.Attributes.Select(x => x.GetType().Name))
        Console.WriteLine(a);
}