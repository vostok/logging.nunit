using NSubstitute;
using NUnit.Framework;
using Vostok.Logging.Abstractions;

namespace Vostok.Logging.NUnit.Tests
{
    [TestFixture]
    internal class NUnitTextWriterLog_Tests
    {
        [Test]
        public void Should_Format_Event()
        {
            var writer = Substitute.For<INUnitMessageWriter>();
            NUnitLog log = new(writer);
            const string message = "Hi, Michiel";

            log.Info(message);

            writer.Received(1).Write(Arg.Is<string>(x => x.Contains(message)));
        }
    }
}