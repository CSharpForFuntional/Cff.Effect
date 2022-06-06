namespace Cff.Effect.Abstractions.Domain;

public readonly record struct Sha<T>(byte[] Value)
{
    public override string ToString() => Convert.ToBase64String(Value);
}
