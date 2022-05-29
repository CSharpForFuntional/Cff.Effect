using LanguageExt.Attributes;
using LanguageExt.Effects.Traits;

namespace Cff.Effect.Abstractions;

public interface IJson
{
    string Serialize<T>(T msg) where T : notnull;
    object? Deserialize(string jsonString);
    Task<object?> DeserializeAsync(Stream stream, CancellationToken ct);
}

[Typeclass("*")]
public interface HasJsonAbstract<RT> : HasCancel<RT>
    where RT : struct, HasJsonAbstract<RT>, HasCancel<RT>
{
    Eff<RT, IJson> JsonEff { get; }
}
