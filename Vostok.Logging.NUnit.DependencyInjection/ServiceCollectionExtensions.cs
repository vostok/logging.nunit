using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework.Internal;

namespace Vostok.Logging.NUnit.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBoundToCurrentTestContextNUnitLog(this IServiceCollection serviceCollection) =>
            serviceCollection
                .AddSingleton<INUnitTextWriterProvider>(new NUnitTestContextTextWriterProvider(TestExecutionContext.CurrentContext))
                .AddSingleton<NUnitTextWriterLog>();

        public static IServiceCollection AddAsyncLocalNUnitLog(this IServiceCollection serviceCollection) =>
            serviceCollection
                .AddSingleton<INUnitTextWriterProvider, NUnitAsyncLocalTextWriterProvider>()
                .AddSingleton<NUnitTextWriterLog>();
    }
}
