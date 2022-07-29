using FluentAssertions;
using NUnit.Framework;

namespace Vostok.Logging.NUnit.Tests.TargetTest
{
    [TestFixture]
    [TestFinishLogger(ActionTargets.Test, false)]
    internal class ContextualLog_Should_Go_To_Test
    {
        [Test]
        public void Test() => true.Should().BeTrue();

        [TestCase(1)]
        [TestCase(2)]
        public void TestCase(int value) => value.Should().BePositive();
    }
}
