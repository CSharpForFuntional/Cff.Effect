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
    where RT : struct, HasJsonAbstract<RT>
{
    IJson Json { get; }
    Eff<RT, IJson> JsonEff => Eff<RT, IJson>(rt => Json);
}
