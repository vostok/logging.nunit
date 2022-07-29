using FluentAssertions;
using NUnit.Framework;

namespace Vostok.Logging.NUnit.Tests.TargetSuite
{
    [TestFixture]
    [TestFinishLogger(ActionTargets.Suite, false)]
    internal class ContextualLog_Should_Go_To_TestFixture
    {
        [Test]
        public void Test() => true.Should().BeTrue();

        [TestCase(1)]
        [TestCase(2)]
        public void TestCase(int value) => value.Should().BePositive();
    }
}
