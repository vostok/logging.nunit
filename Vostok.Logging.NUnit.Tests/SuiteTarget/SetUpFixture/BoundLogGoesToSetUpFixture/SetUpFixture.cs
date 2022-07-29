using NUnit.Framework;

namespace Vostok.Logging.NUnit.Tests.SuiteTarget.SetUpFixture.BoundLogGoesToSetUpFixture
{
    [SetUpFixture]
    [TestFinishLogger(ActionTargets.Suite, true)]
    internal class SetUpFixture
    {
    }
}
