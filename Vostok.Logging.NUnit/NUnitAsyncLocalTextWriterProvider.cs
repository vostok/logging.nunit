using System.Diagnostics.Contracts;
using System.IO;
using NUnit.Framework;

namespace Vostok.Logging.NUnit
{
    /// <summary>
    /// <para>The sink provider which write messages to NUnit immediate output.</para>
    /// <para>It makes use of AsyncLocal to get NUnit TextWriter during a log event write.</para>
    /// </summary>
    public sealed class NUnitAsyncLocalTextWriterProvider : INUnitTextWriterProvider
    {
        /// <inheritdoc />
        [Pure]
        TextWriter INUnitTextWriterProvider.GetWriter() => TestContext.Progress;
    }
}