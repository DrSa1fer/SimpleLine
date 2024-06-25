using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimpleLineLibrary.Models;
using SimpleLineLibrary.Services.Execution.Converting;

namespace SimpleLineLibrary.Services.Execution.Binding
{
    internal class ValueBinder
    {
        public static object?[]? Bind(IReadOnlyList<Parameter> parameters, ExecutionData data, Converter converter)
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
                        throw new ArgumentException($"Required parameter is missing {p.Name}");
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