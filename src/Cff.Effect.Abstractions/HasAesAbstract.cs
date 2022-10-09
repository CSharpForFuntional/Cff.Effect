using LanguageExt.Attributes;
using LanguageExt.Effects.Traits;

namespace Cff.Effect.Abstractions;

public interface IAes
{
    (byte[] Body, byte[] Nonce, byte[] Tag) Encrypt(string source);
    string Decrypt(byte[] body, byte[] nonce, byte[] tag);
}

[Typeclass("*")]
public interface HasAesAbstract<RT> : HasCancel<RT>
    where RT : struct, HasAesAbstract<RT>
{
    Eff<RT, IAes> AesEff => Eff<RT, IAes>(rt => default);
}
