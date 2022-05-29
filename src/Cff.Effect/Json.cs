using Cff.Effect.Abstractions;

namespace Cff.Effect;

public static class Json<RT> where RT : struct, HasJsonAbstract<RT>
{
    public static Eff<RT, string> SerializeEff<T>(T msg) where T : notnull =>
        default(RT).JsonEff.Map(rt => rt.Serialize(msg));

    public static Aff<RT, object?> DeserializeAff(Stream stream, CancellationToken ct) =>
        default(RT).JsonEff.ToAff().Bind(rt => rt.DeserializeAsync(stream, ct).ToValue().ToAff());

    public static Eff<RT, object?> DeserializeEff(string value) =>
        default(RT).JsonEff.Map(rt => rt.Deserialize(value));
}
