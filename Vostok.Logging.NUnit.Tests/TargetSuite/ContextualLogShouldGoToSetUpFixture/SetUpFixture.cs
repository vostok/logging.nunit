using NUnit.Framework;

namespace Vostok.Logging.NUnit.Tests.TargetSuite.ContextualLogShouldGoToSetUpFixture
{
    [SetUpFixture]
    [TestFinishLogger(ActionTargets.Suite, false)]
    internal class SetUpFixture
    {
    }
}
