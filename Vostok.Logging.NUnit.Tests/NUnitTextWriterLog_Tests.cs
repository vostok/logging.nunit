using System.IO;
using System.Text;
using FluentAssertions;
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
            StringBuilder sb = new();
            using StringWriter stringWriter = new(sb);
            var writer = Substitute.For<INUnitTextWriterProvider>();
            writer.GetWriter().Returns(stringWriter);
            NUnitTextWriterLog log = new(writer);
            const string message = "Hi, Michiel";

            log.Info(message);

            sb.ToString().Should().Contain(message);
        }
    }
}