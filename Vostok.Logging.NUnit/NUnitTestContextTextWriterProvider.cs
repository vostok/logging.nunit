using System;
using System.Diagnostics.Contracts;
using System.IO;
using NUnit.Framework.Internal;

namespace Vostok.Logging.NUnit
{
    /// <summary>
    /// <para>The sink provider which writes log events to <see cref="TestExecutionContext"/> of given NUnit test.</para>
    /// </summary>
    public sealed class NUnitTestContextTextWriterProvider : INUnitTextWriterProvider
    {
        private readonly TestExecutionContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="NUnitTestContextTextWriterProvider"/> class.
        /// </summary>
        /// <param name="context">Context of a NUnit test to receive log events.</param>
        public NUnitTestContextTextWriterProvider(TestExecutionContext context)
            => this.context = context ?? throw new ArgumentNullException(nameof(context));

        /// <inheritdoc />
        [Pure]
        TextWriter INUnitTextWriterProvider.GetWriter() => context.OutWriter;
    }
}