using System.Security.Cryptography;
using Cff.Effect.Abstractions;

namespace Cff.Effect.Sha;

internal readonly record struct Sha512() : ISha
{
    public byte[] Serialize(byte[] s) => SHA512.HashData(s);
}
