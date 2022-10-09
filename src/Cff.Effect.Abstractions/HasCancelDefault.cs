using LanguageExt.Attributes;
using LanguageExt.Effects.Traits;

namespace Cff.Effect.Abstractions;

[Typeclass("*")]
public interface HasCancelDefault<RT> : HasCancel<RT>
    where RT : struct, HasCancelDefault<RT>
{
    RT HasCancel<RT>.LocalCancel => new();
    CancellationToken HasCancel<RT>.CancellationToken => CancellationTokenSource.Token;
}
