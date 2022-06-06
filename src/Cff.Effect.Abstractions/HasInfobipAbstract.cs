using LanguageExt.Attributes;
using LanguageExt.Effects.Traits;

namespace Cff.Effect.Abstractions;

public interface IInfobip
{

}

    [Typeclass("*")]
public interface HasInfobipEmailAbstract<RT> : HasCancel<RT>
    where RT : struct, HasInfobipEmailAbstract<RT>
{
    Eff<RT, IInfobip> InfobipEmailEff { get; }
}
