using SimpleLineLibrary.Services.Invokation.Converting;
using SimpleLineLibrary.Models;
using System.Collections;
using SimpleLineLibrary.Services.Invokation.Execution.Exceptions;

namespace SimpleLineLibrary.Services.Invokation.Execution
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
            var bind = Bind(handler.Parameters, input);
            
            try
            {                
                return handler.Invoke(bind);
            }
            catch(Exception ex)
            {
                throw new UserRuntimeException(ex);
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
                        throw new Exception("61");
                    }
                    if (p.HasDefaultValue)
                    {
                        arr[i] = p.DefaultValue;
                        continue;
                    }
                }

                if (p.ValueType.IsAssignableTo(typeof(Array)))
                {
                    throw new NotImplementedException("Array not supported :(");

                    var ls = new List<object?>();
                    
                    var t = p.ValueType.GetElementType()!;

                    foreach (var value in data.GetValues(p))
                    {
                        var str = value;

                        ls.Add(_converter.Convert(str, t));
                    }
                    
                    arr[i] = ls.ToArray();
                }
                else if(p.ValueType.IsAssignableTo(typeof(ICollection)))
                {
                    throw new NotSupportedException("86");
                }
                else
                {
                    var str = data.GetValue(p);
                    var t = p.ValueType;

                    arr[i] = _converter.Convert(str, t);
                }
            }

            return arr;
        }
    }
}