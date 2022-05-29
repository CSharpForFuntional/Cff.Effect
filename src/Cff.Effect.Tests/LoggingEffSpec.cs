using AutoFixture.Xunit2;
using Cff.Effect.Abstractions;
using Cff.Effect.Logging;
using MELT;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace Cff.Effect.Tests;

public record LoggingEffSpec()
{
    public readonly record struct RT(CancellationTokenSource CancellationTokenSource,
                                     ILogger Logger) :
        HasCancelDefault<RT>,
        HasLogging<RT>
    {
    }

    [Theory, AutoData]
    public void Info(string value, CancellationTokenSource cts)
    {
        using var loggerFactory = TestLoggerFactory.Create();
        var logger = loggerFactory.CreateLogger<LoggingEffSpec>();

        var q = from x in Logging<RT>.InfoEff(value)
                select x;

        var rt = new RT(cts, logger);
        var r = q.Run(rt);

        var log = Assert.Single(loggerFactory.Sink.LogEntries);
        Assert.Equal(value, log.Message);
    }

    [Theory, AutoData]
    public void Error1(string value, CancellationTokenSource cts)
    {
        using var loggerFactory = TestLoggerFactory.Create();
        var logger = loggerFactory.CreateLogger<LoggingEffSpec>();

        var q = from x in Logging<RT>.ErrorEff(value)
                select x;

        var rt = new RT(cts, logger);
        var r = q.Run(rt);

        var log = Assert.Single(loggerFactory.Sink.LogEntries);
        Assert.Equal(value, log.Exception?.Message);
    }
}
