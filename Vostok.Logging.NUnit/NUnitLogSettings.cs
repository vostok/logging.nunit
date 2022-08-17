using System;
using NUnit.Framework.Internal;
using Vostok.Logging.Formatting;

namespace Vostok.Logging.NUnit;

public class NUnitLogSettings
{
    private NUnitLogSettings(Func<TestExecutionContext>? contextProvider = null)
    {
        ContextProvider = contextProvider;
    }

    public Func<TestExecutionContext>? ContextProvider { get; }

    public OutputTemplate OutputTemplate { get; set; } = OutputTemplate.Default;

    /// <inheritdoc cref="WithCustomTestContext"/>
    public static NUnitLogSettings WithCurrentTestContext()
    {
        return WithCustomTestContext(TestExecutionContext.CurrentContext);
    }

    /// <summary>
    /// <see cref="NUnitLog"/> instance with this settings will write events to a specific <see cref="TestExecutionContext"/> of given NUnit test.
    /// </summary>
    public static NUnitLogSettings WithCustomTestContext(TestExecutionContext testExecutionContext)
    {
        return new NUnitLogSettings(() => testExecutionContext);
    }

    /// <inheritdoc cref="WithCustomTestContext"/>
    public static NUnitLogSettings WithTestContextProvider(Func<TestExecutionContext> contextProvider)
    {
        return new NUnitLogSettings(contextProvider);
    }

    /// <summary>
    /// <see cref="NUnitLog"/> instance with this settings will write events to NUnit immediate output.
    /// It makes use of AsyncLocal to get NUnit test context during writing of a log event.
    /// This option is recommended for most cases, but it doesn't work well inside any local applications, because the test context may be lost due to AsyncLocal.
    /// Use <see cref="WithCustomTestContext"/> or <see cref="WithCurrentTestContext"/> for such cases.
    /// </summary>
    public static NUnitLogSettings WithAsyncLocalContext()
    {
        return new NUnitLogSettings();
    }
}