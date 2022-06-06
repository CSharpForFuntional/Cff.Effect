using System.Security.Cryptography;
using Cff.Effect.Abstractions;

namespace Cff.Effect.Sha;

internal readonly record struct Sha256() : ISha
{
    public byte[] Serialize(byte[] s) => SHA256.HashData(s);
}
