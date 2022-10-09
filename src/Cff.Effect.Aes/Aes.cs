using System.Security.Cryptography;
using System.Text;
using Cff.Effect.Abstractions;
using Cff.Effect.Abstractions.Domain;

namespace Cff.Effect.Aes;

internal readonly record struct Aes(AesKey AesKey) : IAes
{
    public (byte[] Body, byte[] Nonce, byte[] Tag) Encrypt(string source)
    {
        using var aes = new AesGcm(AesKey.Value);

        var nonce = new byte[AesGcm.NonceByteSizes.MaxSize];
        RandomNumberGenerator.Fill(nonce);

        var plaintextBytes = Encoding.UTF8.GetBytes(source);
        var body = new byte[plaintextBytes.Length];
        var tag = new byte[AesGcm.TagByteSizes.MaxSize];

        aes.Encrypt(nonce, plaintextBytes, body, tag);

        return (body, nonce, tag);
    }

    public string Decrypt(byte[] body, byte[] nonce, byte[] tag)
    {
        using var aes = new AesGcm(AesKey.Value);
        var plaintextBytes = new byte[body.Length];
        aes.Decrypt(nonce, body, tag, plaintextBytes);

        return Encoding.UTF8.GetString(plaintextBytes);
    }
}

