using NUnit.Framework;

namespace Vostok.Logging.NUnit.Tests.TargetTest.ContextualLogShouldGoToTest
{
    [SetUpFixture]
    [TestFinishLogger(ActionTargets.Test, false)]
    internal class SetUpFixture
    {
    }
}
