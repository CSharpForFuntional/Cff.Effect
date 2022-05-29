using Cff.Effect.Abstractions;
using Microsoft.Extensions.Logging;

namespace Cff.Effect.Logging;

internal readonly record struct Logging(ILogger Logger) : ILogging
{
    public Unit Info(string message, params object?[] args)
    {
        Logger.LogInformation(message, args);
        return unit;
    }
}
