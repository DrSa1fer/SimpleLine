using SimpleLineLibrary.Services.Execution.Converting;
using SimpleLineLibrary.Services.Execution.Exceptions;
using SimpleLineLibrary.Models;
using System.Reflection;
using System.Collections;

namespace SimpleLineLibrary.Services.Execution
{
    internal class HandlerExecutor
    {
        internal object? Execute(Handler handler, ExecutionData input, IReadOnlyDictionary<Type, Func<string, object?>> types)
        {            
            try
            {
                if(input.CountOfArgs() != handler.Parameters.Count)
                {
                    throw new ArgumentException("Different count of args and handler paramters");
                }
                if (!handler.AvalibleKeys.All(input.Keys.Contains))
                {
                    throw new ArgumentException("Invalid key");
                }

                var converter = new Converter(types);
                var bind = Bind(handler.Parameters, input, converter);

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

        private object?[]? Bind(IReadOnlyList<Parameter> parameters, ExecutionData data, Converter converter)
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
                    arr[i] = converter.ConvertCollection(p.ValueType, values);
                }
                else
                {
                    var str = data.GetValue(p);
                    var t = p.ValueType;

                    arr[i] = converter.ConvertType(t, str);
                }
            }

            return arr;
        }
    }
}