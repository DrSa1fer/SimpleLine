using SimpleLineLibrary.Services.Execution.Binding.Exceptions;
using SimpleLineLibrary.Services.Execution.Converting;
using SimpleLineLibrary.Models;
using System.Collections;

namespace SimpleLineLibrary.Services.Execution.Binding
{
    internal class ValueBinder
    {
        private readonly Converter _converter;

        public ValueBinder(Converter converter)
        {
            _converter = converter;
        }

        public object?[]? Bind(IReadOnlyList<Parameter> parameters, ExecutionData data)
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
                        throw new RequiredParameterIsMissingException(p.Name);
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
                    var t = p.ValueType;
                    var v = data.GetValues(p);

                    arr[i] = _converter.ConvertCollection(t, v);
                }
                else
                {
                    var t = p.ValueType;
                    var v = data.GetValue(p);

                    arr[i] = _converter.ConvertType(t, v);
                }
            }

            return arr;
        }
    }
}