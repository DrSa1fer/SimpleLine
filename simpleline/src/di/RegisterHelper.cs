using Microsoft.Extensions.DependencyInjection;

namespace simpleline.di;

public static class RegisterHelper
{
    public static IServiceCollection Register(IServiceCollection collection)
    {
        // collection.AddSingleton<>()

        return collection;
    }
}