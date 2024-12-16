// using System.Diagnostics.CodeAnalysis;
// using System.Reflection;
// using simpleline.models;
// using simpleline.services.registration.reflection.actions;
// using simpleline.services.registration.reflection.options;
// using Action = simpleline.models.Action;
//
// namespace simpleline.services.registration.reflection;
//
// public class ReflectionRegistrar(Assembly assembly) : RegistrarBase
// {
//     private IEnumerable<ActionHandlerBase> _actionHandlers = [];
//     private IEnumerable<OptionHandlerBase> _optionHandlers = [];
//     
//     public override Node Register(IEnumerable<TypeInfo> assembly1)
//     {
//         
//     }
//
//     private static bool TryGetRouteAttribute(Type type, [MaybeNullWhen(false)] out IRoute routeAttribute)
//     {
//         routeAttribute = type
//             .GetCustomAttributes()
//             .OfType<IRoute>()
//             .FirstOrDefault();
//         
//         return routeAttribute != null;
//     }
//
//     
//     private IEnumerable<Action> GetActions(Type type)
//     {
//         var jobs = type
//             .GetFields()
//             .Select(field => new
//             {
//                 field,
//                 attr = field
//                     .GetCustomAttributes()
//                     .OfType<IOptionMarker>()
//                     .FirstOrDefault()
//             })
//             .Where(x => x.attr != null)
//             .Select(x => new Action<object?, Context>((obj, input) =>
//                 x.field.SetValue(obj, null /*todo*/)
//             ));
//
//
//
//         foreach (var method in type.GetMethods())
//         {
//             foreach (var attr in method.GetCustomAttributes())
//             {
//                 if (attr is not IActionMarker marker)
//                 {
//                     continue;
//                 }
//                 
//                 var handler = _actionHandlers
//                     .FirstOrDefault(x => x.Is(marker));
//
//                 if (handler == null)
//                 {
//                     throw new InvalidOperationException($"Method {method.Name} has no handler");
//                 }
//                 
//                 handler.Handle(marker, TODO);
//             }
//         }
//
//         return null;
//     }
// }