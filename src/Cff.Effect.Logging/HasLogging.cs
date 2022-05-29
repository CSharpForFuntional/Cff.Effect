using Cff.Effect.Abstractions;
using LanguageExt.Attributes;
using Microsoft.Extensions.Logging;

namespace Cff.Effect.Logging;

[Typeclass("*")]
public interface HasLogging<RT> : HasLoggingAbstract<RT>
    where RT : struct, HasLogging<RT>
{
    ILogger Logger { get; }
    Eff<RT, ILogging> HasLoggingAbstract<RT>.LoggingEff => Eff<RT, ILogging>(rt => new Logging(rt.Logger));
}
