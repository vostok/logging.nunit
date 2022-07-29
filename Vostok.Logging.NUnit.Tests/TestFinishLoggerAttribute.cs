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
    internal sealed class TestFinishLoggerAttribute : NUnitAttribute, ITestAction
    {
        private readonly ILog log;
        private Stopwatch? stopWatch;

        public TestFinishLoggerAttribute(ActionTargets targets, bool bound)
        {
            Targets = targets;

            ServiceCollection serviceCollection = new();
            if (bound)
            {
                serviceCollection.AddBoundToCurrentTestContextNUnitLog();
            }
            else
            {
                serviceCollection.AddAsyncLocalNUnitLog();
            }

            log = serviceCollection.BuildServiceProvider().GetRequiredService<NUnitTextWriterLog>();
        }

        public ActionTargets Targets { get; }

        public void BeforeTest(ITest test) => stopWatch = Stopwatch.StartNew();

        public void AfterTest(ITest test)
        {
            var stopwatch = stopWatch ?? throw new InvalidOperationException("BeforeTest wasn't called");
            log.Info($"Test {test.FullName} finished. Elapsed: {stopwatch.Elapsed}");
        }
    }
}