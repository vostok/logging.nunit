using System.IO;

namespace Vostok.Logging.NUnit
{
    public interface INUnitTextWriterProvider
    {
        TextWriter GetWriter();
    }
}
