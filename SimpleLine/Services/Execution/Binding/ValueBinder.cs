using System.Collections;
using SimpleLineLibrary.Models;
using SimpleLineLibrary.Services.Execution.Converting;

namespace SimpleLineLibrary.Services.Execution.Binding
{
    internal class ValueBinder
    {
        public object?[]? Bind(IReadOnlyList<Parameter> parameters, ExecutionData data, Converter converter)
        {
            var arr = new object?[parameters.Count];

            for (int i = 0; i < parameters.Count; i++)
            {
                var p = parameters[i];

                if (p.ValueType == typeof(bool))
                {
                    if (!data.HasParameter(p))
                    {
                        arr[i] = false;
                        continue;
                    }

                    if (!data.HasValue(p))
                    {
                        arr[i] = true;
                        continue;
                    }
                }

                if (!data.HasParameter(p))
                {
                    if (p.IsRequired)
                    {
                        throw new ArgumentException($"Required parameter is missing {p.Name}");
                    }
                    
                    if (p.HasDefaultValue)
                    {
                        arr[i] = p.DefaultValue;
                        continue;
                    }

                    throw new ArgumentException("Parameter is missing, but he is not required and hasnt default value");
                }

                if (p.ValueType.IsAssignableTo(typeof(ICollection)))
                {
                    var values = data.GetValues(p);
                    arr[i] = converter.ConvertCollection(p.ValueType, values);
                    
                    continue;
                }

                var str = data.GetValue(p);
                var t = p.ValueType;

                arr[i] = converter.ConvertType(t, str);        
            }

            return arr;
        }
    }
}