using System.Reflection;

namespace simpleline.services.registrar;

public static class Filter
{
    public static IEnumerable<TypeInfo> Types(IEnumerable<TypeInfo> infos)
    {
        return infos
            .Where(info => info is
                {
                    IsClass: true,
                    IsAbstract: false,
                    IsGenericType: false,
                }
            )
            .Where(info => info
                .GetCustomAttributes()
                .OfType<IRegisteredAttribute>()
                .Any()
            );
    }
    public static IEnumerable<MethodInfo> Methods(IEnumerable<MethodInfo> infos)
    {
        return infos
            .Where(info => info is
                {
                    IsAbstract: false,
                    IsGenericMethod: false,
                }
            )
            .Where(info => info
                .GetCustomAttributes()
                .OfType<IRegisteredAttribute>()
                .Any()
            );
    }
    public static IEnumerable<FieldInfo> Fields(IEnumerable<FieldInfo> infos)
    {
        return infos
            .Where(info => info is
            {
                IsInitOnly: false,
            })
            .Where(info => info
                .GetCustomAttributes()
                .OfType<IRegisteredAttribute>()
                .Any()
            );
    }
    public static IEnumerable<PropertyInfo> Properties(IEnumerable<PropertyInfo> infos)
    {
        return infos
            .Where(info => info is
            {
                GetMethod: not null,
                SetMethod: not null,
            })
            .Where(info => info
                .GetCustomAttributes()
                .OfType<IRegisteredAttribute>()
                .Any()
            );
    }
}