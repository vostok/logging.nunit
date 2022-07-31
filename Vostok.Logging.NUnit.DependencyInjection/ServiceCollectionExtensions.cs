using System.ComponentModel;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework.Internal;

namespace Vostok.Logging.NUnit.DependencyInjection
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Add <see cref="NUnitLog"/> to services.
        /// The <see cref="NUnitLog"/> writes log events to a test context captured during the service addition.
        /// The test context is captured via AsyncLocal TestExecutionContext.CurrentContext.
        /// It is good as log passed to locally run a Vostok or Houston application.
        /// </summary>
        /// <param name="serviceCollection">A service collection to add log services.</param>
        /// <returns>The same service collection.</returns>
        public static IServiceCollection AddNUnitLogBoundToCurrentTestContext(this IServiceCollection serviceCollection) =>
            serviceCollection
                .AddSingleton<INUnitMessageWriter>(new NUnitTestContextMessageWriter(TestExecutionContext.CurrentContext))
                .AddSingleton<NUnitLog>();

        /// <summary>
        /// Add <see cref="NUnitLog"/> to services.
        /// The <see cref="NUnitLog"/> writes events to test context captured via AsyncLocal during log event message writing.
        /// It is good as general purpose log.
        /// </summary>
        /// <param name="serviceCollection">A service collection to add log services.</param>
        /// <returns>The same service collection.</returns>
        public static IServiceCollection AddNUnitLogWithAsyncLocalProvider(this IServiceCollection serviceCollection) =>
            serviceCollection
                .AddSingleton<INUnitMessageWriter, NUnitAsyncLocalMessageWriter>()
                .AddSingleton<NUnitLog>();
    }
}
