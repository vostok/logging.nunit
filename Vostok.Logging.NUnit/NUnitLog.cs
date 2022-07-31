using System;
using Vostok.Logging.Abstractions;
using Vostok.Logging.Abstractions.Wrappers;
using Vostok.Logging.Formatting;

namespace Vostok.Logging.NUnit
{
    /// <summary>
    /// <para>A log which outputs events to NUnit.</para>
    /// </summary>
    public sealed class NUnitLog : ILog
    {
        private readonly INUnitMessageWriter nunitMessageWriter;

        /// <summary>
        /// Initializes a new instance of the <see cref="NUnitLog"/> class.
        /// </summary>
        /// <param name="nunitMessageWriter">NUnit message writer to write events to.</param>
        public NUnitLog(INUnitMessageWriter nunitMessageWriter)
            => this.nunitMessageWriter = nunitMessageWriter;

        /// <inheritdoc />
        public void Log(LogEvent? @event)
        {
            if (@event is null)
            {
                return;
            }

            var message = LogEventFormatter.Format(@event, OutputTemplate.Default);
            nunitMessageWriter.Write(message);
        }

        /// <inheritdoc />
        public ILog ForContext(string context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            return new SourceContextWrapper(this, context);
        }

        bool ILog.IsEnabledFor(LogLevel level) => true;
    }
}