using NUnit.Framework;

namespace Vostok.Logging.NUnit.Tests.TargetTest.BoundLogShouldGoToSetUpFixture
{
    [SetUpFixture]
    [TestFinishLogger(ActionTargets.Test, true)]
    internal class SetUpFixture
    {
    }
}
