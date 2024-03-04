using SimpleLineLibrary.Src.Entities.Parameters.Abs;

namespace SimpleLineLibrary.Src.Entities.Commands.Handler
{
    public static class CommandHandlerExtention
    {
        public static void SetHandler(this Command command, Action action)
        {
            command.Handler = _ => {
                action(); 
            };
        }

        public static void SetHandler<T>(this Command command, Action<T> action,
            Parameter<T> p)
        {
            command.Handler = data =>
            {
                action(
                    p.GetValue(data));
            };

            command.AddParameterInfo(p.ParameterInfo);
        }

        public static void SetHandler<T0, T1>(this Command command, Action<T0, T1> action,
            Parameter<T0> p0, Parameter<T1> p1)
        {
            command.Handler = data => { 
                action(
                    p0.GetValue(data),
                    p1.GetValue(data)); 
            };

            command.AddParameterInfo(p0.ParameterInfo);
            command.AddParameterInfo(p1.ParameterInfo);
        }

        public static void SetHandler<T0, T1, T2>(this Command command,
            Action<T0, T1, T2> action,
            Parameter<T0> p0,
            Parameter<T1> p1,
            Parameter<T2> p2)
        {
            command.Handler = data => { 
                action(
                    p0.GetValue(data),
                    p1.GetValue(data),
                    p2.GetValue(data));
            };

            command.AddParameterInfo(p0.ParameterInfo);
            command.AddParameterInfo(p1.ParameterInfo);
            command.AddParameterInfo(p2.ParameterInfo);
        }

        public static void SetHandler<T0, T1, T2, T3>(this Command command, 
            Action<T0, T1, T2, T3> action,
            Parameter<T0> p0,
            Parameter<T1> p1,
            Parameter<T2> p2, 
            Parameter<T3> p3)
        {
            command.Handler = data => {
                action(
                    p0.GetValue(data),
                    p1.GetValue(data),
                    p2.GetValue(data),
                    p3.GetValue(data)); 
            };

            command.AddParameterInfo(p0.ParameterInfo);
            command.AddParameterInfo(p1.ParameterInfo);
            command.AddParameterInfo(p2.ParameterInfo);
            command.AddParameterInfo(p3.ParameterInfo);
        }

        public static void SetHandler<T0, T1, T2, T3, T4>(this Command command, Action<T0, T1, T2, T3, T4> action,
            Parameter<T0> p0, Parameter<T1> p1, Parameter<T2> p2, Parameter<T3> p3, Parameter<T4> p4)
        {
            command.Handler = data =>
            {
                action(
                    p0.GetValue(data),
                    p1.GetValue(data),
                    p2.GetValue(data),
                    p3.GetValue(data),
                    p4.GetValue(data));
            };

            command.AddParameterInfo(p0.ParameterInfo);
            command.AddParameterInfo(p1.ParameterInfo);
            command.AddParameterInfo(p2.ParameterInfo);
            command.AddParameterInfo(p3.ParameterInfo);
            command.AddParameterInfo(p4.ParameterInfo);
        }
    }
}