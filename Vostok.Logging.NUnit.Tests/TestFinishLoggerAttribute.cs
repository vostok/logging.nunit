using System;
using System.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using Vostok.Logging.Abstractions;
using Vostok.Logging.NUnit.DependencyInjection;

namespace Vostok.Logging.NUnit.Tests
{
    [AttributeUsage(AttributeTargets.Class)]
    internal sealed class TestFinishLoggerAttribute : ParallelizableAttribute, ITestAction
    {
        private readonly Stopwatch stopwatch = new();
        private readonly ILog log;

        public TestFinishLoggerAttribute(ActionTargets targets, bool bound)
            : base(ParallelScope.Fixtures)
        {
            Targets = targets;

            ServiceCollection serviceCollection = new();
            if (bound)
            {
                serviceCollection.AddNUnitLogBoundToCurrentTestContext();
            }
            else
            {
                serviceCollection.AddNUnitLogWithAsyncLocalProvider();
            }

            log = serviceCollection.BuildServiceProvider().GetRequiredService<NUnitLog>();
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