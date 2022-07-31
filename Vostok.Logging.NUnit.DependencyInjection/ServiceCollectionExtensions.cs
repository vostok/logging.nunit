using System.ComponentModel;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework.Internal;

namespace Vostok.Logging.NUnit.DependencyInjection
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Add <see cref="NUnitLog"/> which writes log events to a test context captured during service addition.
        /// The test context is captured via AsyncLocal.
        /// </summary>
        /// <param name="serviceCollection">A service collection to add log services.</param>
        /// <returns>The same service collection.</returns>
        public static IServiceCollection AddBoundToCurrentTestContextNUnitLog(this IServiceCollection serviceCollection) =>
            serviceCollection
                .AddSingleton<INUnitMessageWriter>(new NUnitTestContextMessageWriter(TestExecutionContext.CurrentContext))
                .AddSingleton<NUnitLog>();

        /// <summary>
        /// Add <see cref="NUnitLog"/> which writes events to test context captured via AsyncLocal during event message write.
        /// </summary>
        /// <param name="serviceCollection">A service collection to add log services.</param>
        /// <returns>The same service collection.</returns>
        public static IServiceCollection AddAsyncLocalNUnitLog(this IServiceCollection serviceCollection) =>
            serviceCollection
                .AddSingleton<INUnitMessageWriter, NUnitAsyncLocalMessageWriter>()
                .AddSingleton<NUnitLog>();
    }
}
