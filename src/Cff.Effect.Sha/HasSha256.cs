using Cff.Effect.Abstractions;
using LanguageExt.Attributes;

namespace Cff.Effect.Sha;

[Typeclass("*")]
public interface HasSha256<RT> : HasShaAbstract<RT>
    where RT : struct, HasSha256<RT>
{
    Eff<RT, ISha> HasShaAbstract<RT>.ShaEff => Eff<RT, ISha>(rt => new Sha256());
}
