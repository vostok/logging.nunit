using System;
using NUnit.Framework.Internal;

namespace Vostok.Logging.NUnit
{
    /// <summary>
    /// <para>The NUnit message writer which writes log events to a specific <see cref="TestExecutionContext"/> of given NUnit test.</para>
    /// </summary>
    public sealed class NUnitTestContextMessageWriter : INUnitMessageWriter
    {
        private readonly TestExecutionContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="NUnitTestContextMessageWriter"/> class.
        /// </summary>
        /// <param name="context">Context of a NUnit test to receive log events.</param>
        public NUnitTestContextMessageWriter(TestExecutionContext context)
            => this.context = context ?? throw new ArgumentNullException(nameof(context));

        void INUnitMessageWriter.Write(string message) => context.OutWriter.Write(message);
    }
}