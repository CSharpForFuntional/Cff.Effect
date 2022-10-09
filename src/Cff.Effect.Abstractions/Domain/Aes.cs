namespace Cff.Effect.Abstractions.Domain;

public readonly record struct Aes<T>(byte[] Body,
                                     byte[] Nonce,
                                     byte[] Tag)
{
    public static Aes<T> Of(byte[] body, byte[] nonce, byte[] tag) => new(body, nonce, tag);
}
