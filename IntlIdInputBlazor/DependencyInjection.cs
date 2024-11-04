using Microsoft.Extensions.DependencyInjection;

namespace IntlIdInputBlazor;

public static class DependencyInjection
{
    public static IServiceCollection RegisterIntlIdInput(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IntlIdInputJsInterop>();
        return serviceCollection;
    }
}