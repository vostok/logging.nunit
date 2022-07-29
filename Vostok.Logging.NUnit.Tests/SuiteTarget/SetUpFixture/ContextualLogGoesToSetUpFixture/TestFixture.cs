using FluentAssertions;
using NUnit.Framework;

namespace Vostok.Logging.NUnit.Tests.SuiteTarget.SetUpFixture.ContextualLogGoesToSetUpFixture
{
    [TestFixture]
    internal class TestFixture
    {
        [Test]
        public void Test() => true.Should().BeTrue();

        [TestCase(1)]
        [TestCase(2)]
        public void TestCase(int value) => value.Should().BePositive();
    }
}
