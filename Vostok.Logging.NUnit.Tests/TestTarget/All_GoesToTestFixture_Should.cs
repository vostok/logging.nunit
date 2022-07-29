using FluentAssertions;
using NUnit.Framework;

namespace Vostok.Logging.NUnit.Tests.TestTarget
{
    [TestFixture]
    [TestFinishLogger(ActionTargets.Test, true)]
    internal class All_GoesToTestFixture_Should
    {
        [Test]
        public void Test() => true.Should().BeTrue();

        [TestCase(1)]
        [TestCase(2)]
        public void TestCase(int value) => value.Should().BePositive();
    }
}
