using LanguageExt.Attributes;
using LanguageExt.Effects.Traits;

namespace Cff.Effect.Abstractions;

public interface ILogging
{
    Unit Info(string message, params object?[] args);
}

[Typeclass("*")]
public interface HasLoggingAbstract<RT> : HasCancel<RT>
    where RT : struct, HasLoggingAbstract<RT>
{
    ILogging Logging { get; }
    Eff<RT, ILogging> LoggingEff => Eff<RT, ILogging>(rt => Logging);
}
