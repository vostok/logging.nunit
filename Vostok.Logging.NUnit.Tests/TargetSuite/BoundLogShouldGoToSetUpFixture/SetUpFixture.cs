using NUnit.Framework;

namespace Vostok.Logging.NUnit.Tests.TargetSuite.BoundLogShouldGoToSetUpFixture
{
    [SetUpFixture]
    [TestFinishLogger(ActionTargets.Suite, true)]
    internal class SetUpFixture
    {
    }
}
