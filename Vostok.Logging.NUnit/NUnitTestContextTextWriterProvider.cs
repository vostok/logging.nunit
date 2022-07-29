using System.Diagnostics.Contracts;
using System.IO;
using NUnit.Framework.Internal;

namespace Vostok.Logging.NUnit
{
    public sealed class NUnitTestContextTextWriterProvider : INUnitTextWriterProvider
    {
        private readonly TestExecutionContext context;

        public NUnitTestContextTextWriterProvider(TestExecutionContext context)
        {
            this.context = context;
        }

        [Pure]
        public TextWriter GetWriter() => context.OutWriter;
    }
}