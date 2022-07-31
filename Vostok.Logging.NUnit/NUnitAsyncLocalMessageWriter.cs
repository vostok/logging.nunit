using NUnit.Framework;

namespace Vostok.Logging.NUnit
{
    /// <summary>
    /// <para>The NUnit message writer which write messages to NUnit immediate output.</para>
    /// <para>It makes use of AsyncLocal to get NUnit test context during writing of a log event.</para>
    /// <para>It doesn't work inside Vostok or Houston applications that runs locally. Use <see cref="NUnitTestContextMessageWriter"/> instead for such cases.</para>
    /// </summary>
    public sealed class NUnitAsyncLocalMessageWriter : INUnitMessageWriter
    {
        void INUnitMessageWriter.Write(string message) => TestContext.Progress.Write(message);
    }
}