using AutoFixture.Xunit2;
using Castle.Core.Logging;
using Cff.Effect.Abstractions;
using Cff.Effect.Logging;
using Microsoft.Extensions.Logging;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace Cff.Effect.Tests;

public record LoggingEffSpec(ILogger<LoggingEffSpec> Logger)
{
    public readonly record struct RT(CancellationTokenSource CancellationTokenSource,
                                     ILogger Logger) :
        HasCancelDefault<RT>,
        HasLogging<RT>
    {
    }

    [Theory, AutoData]
    public async Task Info(string value, CancellationTokenSource cts)
    {
        var q = from x in Logging<RT>.Info(value)
                select x;

        var r = q.Run(new RT(cts, Logger));


    }
}
