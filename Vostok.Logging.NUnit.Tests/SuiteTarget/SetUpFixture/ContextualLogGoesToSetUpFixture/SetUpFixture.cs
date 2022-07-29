using NUnit.Framework;

namespace Vostok.Logging.NUnit.Tests.SuiteTarget.SetUpFixture.ContextualLogGoesToSetUpFixture
{
    [SetUpFixture]
    [TestFinishLogger(ActionTargets.Suite, false)]
    internal class SetUpFixture
    {
    }
}
