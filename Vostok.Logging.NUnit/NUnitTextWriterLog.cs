using System;
using Vostok.Logging.Abstractions;
using Vostok.Logging.Abstractions.Wrappers;
using Vostok.Logging.Formatting;

namespace Vostok.Logging.NUnit
{
    /// <summary>
    /// <para>A log which outputs events to NUnit.</para>
    /// </summary>
    public sealed class NUnitTextWriterLog : ILog
    {
        private readonly INUnitTextWriterProvider nunitTextWriterProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="NUnitTextWriterLog"/> class.
        /// </summary>
        /// <param name="nunitTextWriterProvider">NUnit sink provider to write events to.</param>
        public NUnitTextWriterLog(INUnitTextWriterProvider nunitTextWriterProvider)
            => this.nunitTextWriterProvider = nunitTextWriterProvider;

        /// <inheritdoc />
        public void Log(LogEvent? @event)
        {
            if (@event is null)
            {
                return;
            }

            var message = LogEventFormatter.Format(@event, OutputTemplate.Default);
            nunitTextWriterProvider.GetWriter().Write(message);
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