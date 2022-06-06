using AutoFixture.Xunit2;
using Cff.Effect.Abstractions;
using Cff.Effect.Json;
using Cff.Effect.Sha;

namespace Cff.Effect.Tests;

public class Sha512EffSpec
{
    public readonly record struct RT(CancellationTokenSource CancellationTokenSource) :
        HasCancelDefault<RT>,
        HasJson<RT>,
        HasSha512<RT>
    {
    }

    [Theory, AutoData]
    public void Serialize(CancellationTokenSource cts)
    {
        var value = "1";

        var q = from x in Sha<RT>.SerializeEff(value)
                select x;

        var r = q.Run(new RT(cts));

        Assert.Equal("KD6gXujH1nFIpBBoy6ak4BsEvCb2d+IhtC9l0vxtCaPgfYfTXq4aee5Yhm5eOMNQJLldZqIwiI7auvtfpGetkg==", r.ThrowIfFail().ToString());
    }
}
