using System;
using System.Diagnostics;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using Vostok.Logging.Abstractions;

namespace Vostok.Logging.NUnit.Tests
{
    [AttributeUsage(AttributeTargets.Class)]
    internal class TestFinishLoggerAttribute : ParallelizableAttribute, ITestAction
    {
        private readonly Stopwatch stopwatch = new();
        private readonly ILog log;

        public TestFinishLoggerAttribute(ActionTargets targets, bool bound)
            : base(ParallelScope.Fixtures)
        {
            Targets = targets;

            var settings = bound
                ? NUnitLogSettings.WithCurrentTestContext()
                : NUnitLogSettings.WithAsyncLocalContext();

            log = new NUnitLog(settings);
        }

        public ActionTargets Targets { get; }

        public void BeforeTest(ITest test) => stopwatch.Start();

        public void AfterTest(ITest test)
        {
            log.Info($"Test {test.FullName} finished. Elapsed: {stopwatch.Elapsed}");
            stopwatch.Reset();
        }
    }
}