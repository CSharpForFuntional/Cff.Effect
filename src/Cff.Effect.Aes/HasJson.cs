using System.Text.Json;
using Cff.Effect.Abstractions;
using Cff.Effect.Abstractions.Domain;
using LanguageExt.Attributes;

namespace Cff.Effect.Aes;

[Typeclass("*")]
public interface HasAes<RT> : HasAesAbstract<RT>
    where RT : struct, HasAes<RT>
{
    AesKey AesKey { get;}
    Eff<RT, IAes> HasAesAbstract<RT>.AesEff => Eff<RT, IAes>(rt => new Aes(rt.AesKey));
}
