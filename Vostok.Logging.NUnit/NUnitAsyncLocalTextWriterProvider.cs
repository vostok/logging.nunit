using System.Diagnostics.Contracts;
using System.IO;
using NUnit.Framework;

namespace Vostok.Logging.NUnit
{
    public sealed class NUnitAsyncLocalTextWriterProvider : INUnitTextWriterProvider
    {
        [Pure]
        public TextWriter GetWriter() => TestContext.Progress;
    }
}