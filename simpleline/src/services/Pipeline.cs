using simpleline.models;
using simpleline.services.binder;
using simpleline.services.registrar;
using simpleline.services.router;
using simpleline.services.tokenizer;
using simpleline.services.typizer;

namespace simpleline.services;

public class Pipeline
{
    public void Run(Context context)
    {
        var tokenizer = new Tokenizer();
        var registrar = new Registrar();
        var router = new Router();
        var typizer = new Typizer();
        var binder = new Binder();
        
        var commands = registrar.Register(default);
        var command = router.Route(default);

        
        
        
        
        foreach (var option in command.Options)
        {
            binder.Bind(option);
        }
        
        
        
        
        throw new NotImplementedException();
    }
}