using AutoFixture.Xunit2;
using Cff.Effect.Abstractions;
using Cff.Effect.Json;

namespace Cff.Effect.Tests;

public class JsonEffSpec
{
    public readonly record struct RT(CancellationTokenSource CancellationTokenSource) :
        HasCancelDefault<RT>,
        HasJson<RT>
    {
    }

    [Theory, AutoData]
    public void Serialize(string value, CancellationTokenSource cts)
    {
        var q = Json<RT>.SerializeEff(value);
        var r = q.Run(new RT(cts));

        Assert.Equal($"{{\"A\":\"System.Private.CoreLib\",\"T\":\"System.String\",\"V\":\"{value}\"}}", r.ThrowIfFail());
    }

    [Theory, AutoData]
    public void Deserialize(CancellationTokenSource cts)
    {
        var value = "{\"A\":\"System.Private.CoreLib\",\"T\":\"System.String\",\"V\":\"value9cf21a70-afd1-4031-b622-85cd54870724\"}";

        var q = Json<RT>.DeserializeEff(value);
        var r = q.Run(new RT(cts));

        Assert.Equal("value9cf21a70-afd1-4031-b622-85cd54870724", r.ThrowIfFail());
    }
}
