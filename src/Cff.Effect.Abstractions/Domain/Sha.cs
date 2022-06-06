namespace Cff.Effect.Abstractions.Domain;

public record Sha<T>(byte[] Value)
{
    public override string ToString() => Convert.ToBase64String(Value);
}
