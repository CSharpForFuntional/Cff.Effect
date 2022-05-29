using LanguageExt.Attributes;
using LanguageExt.Effects.Traits;

namespace Cff.Effect.Abstractions;

public interface ILogging
{
    Unit Error(Exception ex, string message, params object?[] args);
    Unit Error(Error ex, string message, params object?[] args);
    Unit Info(string message, params object?[] args);
}

[Typeclass("*")]
public interface HasLoggingAbstract<RT> : HasCancel<RT>
    where RT : struct, HasLoggingAbstract<RT>
{
    Eff<RT, ILogging> LoggingEff { get; }
}
