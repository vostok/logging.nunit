using Vostok.Logging.Abstractions;
using Vostok.Logging.Formatting;

namespace Vostok.Logging.NUnit
{
    public sealed class NUnitTextWriterLog : ILog
    {
        private readonly INUnitTextWriterProvider nunitTextWriterProvider;

        public NUnitTextWriterLog(INUnitTextWriterProvider nunitTextWriterProvider)
        {
            this.nunitTextWriterProvider = nunitTextWriterProvider;
        }

        public void Log(LogEvent? @event)
        {
            if (@event is null)
            {
                return;
            }

            var message = LogEventFormatter.Format(@event, OutputTemplate.Default);
            nunitTextWriterProvider.GetWriter().Write(message);
        }

        bool ILog.IsEnabledFor(LogLevel level) => true;

        ILog ILog.ForContext(string context) => this;
    }
}