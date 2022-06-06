using Cff.Effect.Abstractions.Domain;
using LanguageExt.Attributes;
using LanguageExt.Effects.Traits;

namespace Cff.Effect.Abstractions;

public interface ISha
{
    byte[] Serialize(byte[] s);
}

[Typeclass("*")]
public interface HasShaAbstract<RT> : HasCancel<RT>
    where RT : struct, HasShaAbstract<RT>
{
    Eff<RT, ISha> ShaEff { get; }
}
