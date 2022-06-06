using System.Text;
using Cff.Effect.Abstractions;

namespace Cff.Effect;

public static class Sha<RT> where RT : struct, HasShaAbstract<RT>, HasJsonAbstract<RT>
{
    public static Eff<RT, Abstractions.Domain.Sha<T>> SerializeEff<T>(T msg) where T : notnull =>
        from json in default(RT).JsonEff
        from sha in default(RT).ShaEff
        let _1 = json.Serialize(msg)
        let _2 = Encoding.UTF8.GetBytes(_1)
        let _3 = sha.Serialize(_2)
        select new Abstractions.Domain.Sha<T>(_3);
}
