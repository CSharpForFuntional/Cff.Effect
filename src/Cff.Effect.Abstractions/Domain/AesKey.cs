using System.ComponentModel.DataAnnotations;

namespace Cff.Effect.Abstractions.Domain;

public record AesKey([property: MinLength(32), MaxLength(32)] byte[] Value)
{
    public override string ToString() => Convert.ToBase64String(Value);
    public static AesKey FromBase64String(string v) => new(Convert.FromBase64String(v));
}
