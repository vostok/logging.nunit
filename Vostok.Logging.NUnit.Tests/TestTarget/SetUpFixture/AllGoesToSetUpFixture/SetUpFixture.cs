using NUnit.Framework;

namespace Vostok.Logging.NUnit.Tests.TestTarget.SetUpFixture.AllGoesToSetUpFixture
{
    [SetUpFixture]
    [TestFinishLogger(ActionTargets.Test, true)]
    internal class SetUpFixture
    {
    }
}
