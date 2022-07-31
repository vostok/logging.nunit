namespace Vostok.Logging.NUnit
{
    /// <summary>
    /// <para>A NUnit message writer to use with the <see cref="NUnitLog"/>.</para>
    /// </summary>
    public interface INUnitMessageWriter
    {
        /// <summary>
        /// Write log events to NUnit.
        /// </summary>
        /// <param name="message">Text message to send to NUnit output.</param>
        void Write(string message);
    }
}