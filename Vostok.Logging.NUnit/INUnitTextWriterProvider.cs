using System.IO;

namespace Vostok.Logging.NUnit
{
    /// <summary>
    /// <para>A NUnit sink provider to use with the <see cref="NUnitTextWriterLog"/>.</para>
    /// </summary>
    public interface INUnitTextWriterProvider
    {
        /// <summary>
        /// Returns a NUnit sink to write log events to.
        /// </summary>
        /// <returns>The target sink.</returns>
        TextWriter GetWriter();
    }
}