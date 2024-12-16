using System.Reflection;
using simpleline.models;

namespace simpleline.services.registration;

public class Registrar : RegistrarBase
{
    public override Node Register(Context context)
    {
        var root = new Node("");
        
        var filtered = context
            .ApplicationConfig
            .DefinedTypes
            .Where(typeInfo => typeInfo is
            {
                IsClass: true,
                IsAbstract: false,
                IsGenericType: false
            }
        );
        
        foreach (var type in filtered)
        {
            var attr = type
                .GetCustomAttributes()
                .OfType<IRegistered>()
                .FirstOrDefault();

            if (attr == null)
            {
                continue;
            }
            
            var route = attr.Route.Split([' '], StringSplitOptions.RemoveEmptyEntries);
            var target = GetNode(root, route);

            
            target.Type = type;
        }

        return root;
    }

    private static Node GetNode(Node root, IEnumerable<string> route)
    {
        var target = root;

        foreach (var i in route)
        {
            var t = target
                .Next
                .FirstOrDefault(
                    node => node.Symbol == i
                );

            if (t == null)
            {
                var node = new Node(i);
                target.Next.Add(node);
                t = node;
            }

            target = t;
        }

        return target;
    }
}