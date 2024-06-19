using SimpleLineLibrary.Services.Execution.Converting;
using SimpleLineLibrary.Services.Execution.Exceptions;
using SimpleLineLibrary.Models;
using System.Reflection;
using System.Collections;
using SimpleLineLibrary.Services.Logging;

namespace SimpleLineLibrary.Services.Execution
{
    internal class HandlerExecutor
    {
        private readonly Converter _converter;  

        public HandlerExecutor(Converter converter)
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
                throw new UserRuntimeException(ex.InnerException);
            }            
            catch
            {
                throw;
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
                    arr[i] = _converter.ConvertCollection(p.ValueType, values);
                }
                else
                {
                    var str = data.GetValue(p);
                    var t = p.ValueType;

                    arr[i] = _converter.ConvertType(t, str);
                }
            }

            return arr;
        }
    }
}