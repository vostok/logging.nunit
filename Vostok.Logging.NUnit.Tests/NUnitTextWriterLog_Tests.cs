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
            var writer = Substitute.For<INUnitTextWriterProvider>();
            using StringWriter stringWriter = new(sb);
            writer.GetWriter().Returns(stringWriter);
            NUnitTextWriterLog log = new(writer);
            const string message = "Hi, Michiel";

            log.Info(message);

            sb.ToString().Should().Contain(message);
        }
    }
}