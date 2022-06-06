namespace Cff.Effect.Abstractions.Domain;

public readonly record struct Aes<T>(byte[] Body,
                                     byte[] Nonce,
                                     byte[] Tag)
{
    public Aes((byte[] Body, byte[] Nonce, byte[] Tag) v) : this(v.Body, v.Nonce, v.Tag) { }
}
