using System.Text.Json;
using Cff.Effect.Abstractions;
using LanguageExt.Attributes;

namespace Cff.Effect.Json;

[Typeclass("*")]
public interface HasJson<RT> : HasJsonAbstract<RT>
    where RT : struct, HasJsonAbstract<RT>
{
    IJson HasJsonAbstract<RT>.Json => new Json(new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = false,
    });
}
