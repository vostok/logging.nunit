using System;
using NUnit.Framework.Internal;
using Vostok.Logging.Formatting;

namespace Vostok.Logging.NUnit;

public class NUnitLogSettings
{
    public Func<TestExecutionContext>? ContextProvider { get; set; }

    public OutputTemplate OutputTemplate { get; set; } = OutputTemplate.Default;
}