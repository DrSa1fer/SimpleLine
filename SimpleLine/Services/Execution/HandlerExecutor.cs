using SimpleLineLibrary.Services.Execution.Exceptions.Binding;
using SimpleLineLibrary.Services.Execution.Exceptions;
using SimpleLineLibrary.Services.Converting;
using SimpleLineLibrary.Models;
using System.Collections;
using System.Reflection;

namespace SimpleLineLibrary.Services.Execution
{
    internal class HandlerExecutor
    {
        private readonly ConverterProvider _converter;

        public HandlerExecutor(ConverterProvider converter)
        {
            _converter = converter;
        }

        internal object? Execute(Handler handler, ExecutionData input)
        {            
            try
            {
                var bind = Bind(handler.Parameters, input);
                return handler.Invoke(bind);
            }
            catch (TargetInvocationException ex)
            {
                throw new UserRuntimeException(ex);
            }
            catch (Exception ex)
            {
                throw new ExecutionException(ex);
            }
        }

        private object?[]? Bind(IReadOnlyList<Parameter> parameters, ExecutionData data)
        {
            var arr = new object?[parameters.Count];

            for (int i = 0; i < parameters.Count; i++)
            {
                var p = parameters[i];

                if (p.ValueType == typeof(bool))
                {
                    if (data.HasParameter(p))
                    {
                        if (!data.HasValue(p))
                        {
                            arr[i] = true;
                            continue;
                        }
                    }
                    else
                    {
                        arr[i] = false;
                        continue;
                    }
                }

                if (!data.HasParameter(p))
                {
                    if (p.IsRequired)
                    {
                        throw new NoRequiredParameterException(p.Name);
                    }
                    if (p.HasDefaultValue)
                    {
                        arr[i] = p.DefaultValue;
                        continue;
                    }
                }

                if (p.ValueType.IsAssignableTo(typeof(ICollection)))
                {
                    var values = data.GetValues(p);
                    arr[i] = _converter.ConvertEnumerable(p.ValueType, values);
                }
                else
                {
                    var str = data.GetValue(p);
                    var t = p.ValueType;

                    arr[i] = Convert(str, t);                    
                }
            }

            return arr;
        }

        private object? Convert(string input, Type t)
        {
            if (_converter.IsSupported(t))
            {
                return _converter.ConvertType(t, input);
            }
            else
            {
                throw new NotSupportedTypeException(t);
            }
        }
    }
}