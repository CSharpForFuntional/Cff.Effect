using System.Text;
using Cff.Effect.Abstractions;

namespace Cff.Effect;

public static class Aes<RT> where RT : struct, HasAesAbstract<RT>, HasJsonAbstract<RT>
{
    public static Eff<RT, Abstractions.Domain.Aes<T>> EncryptEff<T>(T msg) where T : notnull =>
        from json in default(RT).JsonEff
        from sha in default(RT).AesEff
        let _1 = json.Serialize(msg)
        let _2 = sha.Encrypt(_1)
        select Abstractions.Domain.Aes<T>.Of(_2.Body, _2.Nonce, _2.Tag);

    public static Eff<RT, T> DecryptEff<T>(Abstractions.Domain.Aes<T> msg) where T : notnull =>
        from json in default(RT).JsonEff
        from sha in default(RT).AesEff
        let _1 = sha.Decrypt(msg.Body, msg.Nonce, msg.Tag)
        let _2 = json.Deserialize(_1)
        select (T)_2;
}
