using NUnit.Framework;

namespace Vostok.Logging.NUnit.Tests.TestTarget.SetUpFixture.AllGoesToTest
{
    [SetUpFixture]
    [TestFinishLogger(ActionTargets.Test, false)]
    internal class SetUpFixture
    {
    }
}
