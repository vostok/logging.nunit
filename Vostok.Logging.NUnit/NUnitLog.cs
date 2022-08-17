using System;
using NUnit.Framework;
using Vostok.Logging.Abstractions;
using Vostok.Logging.Abstractions.Wrappers;
using Vostok.Logging.Formatting;

namespace Vostok.Logging.NUnit
{
    /// <summary>
    /// <para>A log which outputs events to NUnit.</para>
    /// </summary>
    public class NUnitLog : ILog
    {
        private readonly NUnitLogSettings settings;

        public NUnitLog(NUnitLogSettings settings)
            => this.settings = settings;

        /// <inheritdoc />
        public void Log(LogEvent? @event)
        {
            if (@event is null)
            {
                return;
            }

            var message = LogEventFormatter.Format(@event, settings.OutputTemplate);
            (settings.ContextProvider?.Invoke().OutWriter ?? TestContext.Progress).Write(message);
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