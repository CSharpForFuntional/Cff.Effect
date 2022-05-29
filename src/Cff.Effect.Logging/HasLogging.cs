using Cff.Effect.Abstractions;
using LanguageExt.Attributes;
using Microsoft.Extensions.Logging;

namespace Cff.Effect.Logging;

[Typeclass("*")]
public interface HasLogging<RT> : HasLoggingAbstract<RT>
    where RT : struct, HasLoggingAbstract<RT>
{
    ILogger Logger { get; }
    ILogging HasLoggingAbstract<RT>.Logging => new Logging(Logger);
}
