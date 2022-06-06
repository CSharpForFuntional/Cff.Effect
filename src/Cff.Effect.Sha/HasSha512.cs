using Cff.Effect.Abstractions;
using LanguageExt.Attributes;

namespace Cff.Effect.Sha;

[Typeclass("*")]
public interface HasSha512<RT> : HasShaAbstract<RT>
    where RT : struct, HasSha512<RT>
{
    Eff<RT, ISha> HasShaAbstract<RT>.ShaEff => Eff<RT, ISha>(rt => new Sha512());
}
