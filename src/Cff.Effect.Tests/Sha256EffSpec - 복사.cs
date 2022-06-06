using AutoFixture.Xunit2;
using Cff.Effect.Abstractions;
using Cff.Effect.Abstractions.Domain;
using Cff.Effect.Aes;
using Cff.Effect.Json;
using Cff.Effect.Sha;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Cff.Effect.Tests;

public class Aes256EffSpec
{
    public readonly record struct RT(CancellationTokenSource CancellationTokenSource,
                                     Abstractions.Domain.AesKey AesKey) :
        HasCancelDefault<RT>,
        HasJson<RT>,
        HasAes<RT>
    {
    }

    public record Stub(string Value, int Index);

    [Theory, AutoData]
    public async Task EncryptAndDecrypt(Stub value, CancellationTokenSource cts!!, AesKey aesKey)
    {
        var q = from _1 in Aes<RT>.EncryptEff(value)
                from _2 in Aes<RT>.DecryptEff(_1)
                select _2;

        var r = q.Run(new RT(cts, aesKey));

        Assert.Equal(value, r.ThrowIfFail());
    }
}
