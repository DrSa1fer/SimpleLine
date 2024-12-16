// using System.Reflection;
// using simpleline.models;
// using Action = simpleline.models.Action;
//
// namespace simpleline.services.registration.reflection.actions;
//
// public abstract class ActionHandlerBase
// {
//     public abstract bool Is(IActionMarker mark);
//     public abstract Action Handle(IActionMarker mark, Action.DoDelegate @do);
// }
//
// public abstract class ActionHandlerBase<T> : ActionHandlerBase where T : IActionMarker
// {
//     public sealed override bool Is(IActionMarker mark)
//     {
//         return typeof(T) == mark.GetType();
//     }
//
//     public sealed override Action Handle(IActionMarker mark, Action.DoDelegate @do)
//     {
//         return new Action(
//             Handle((T)mark),
//             @do
//         );
//     }
//
//     protected abstract Action.IsDelegate Handle(T mark);
// }

