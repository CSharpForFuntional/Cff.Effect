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

    public Unit Error(Exception ex, string message, params object?[] args)
    {
        Logger.LogError(ex, message, args);
        return unit;
    }

    public Unit Error(Error ex, string message, params object?[] args)
    {
        Logger.LogError(ex.Exception.Match(x => x, new Exception(ex.Message)), message, args);
        return unit;
    }
}
