using Vostok.Logging.Abstractions;
using Vostok.Logging.Formatting;

namespace Vostok.Logging.NUnit
{
    public sealed class NUnitTextWriterLog : ILog
    {
        private readonly INUnitTextWriterProvider inUnitTextWriterProvider;

        public NUnitTextWriterLog(INUnitTextWriterProvider inUnitTextWriterProvider)
        {
            this.inUnitTextWriterProvider = inUnitTextWriterProvider;
        }

        public void Log(LogEvent? @event)
        {
            if (@event is null)
            {
                return;
            }

            var message = LogEventFormatter.Format(@event, OutputTemplate.Default);
            inUnitTextWriterProvider.GetWriter().Write(message);
        }

        public bool IsEnabledFor(LogLevel level) => true;

        public ILog ForContext(string context) => this;
    }
}