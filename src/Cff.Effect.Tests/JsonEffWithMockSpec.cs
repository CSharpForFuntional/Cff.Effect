using AutoFixture.Xunit2;
using Cff.Effect.Abstractions;
using Moq;

namespace Cff.Effect.Tests;

public class JsonEffWithMockSpec
{
    public readonly record struct RT(CancellationTokenSource CancellationTokenSource,
                                     IJson Json) :
        HasCancelDefault<RT>,
        HasJsonAbstract<RT>
    {
    }

    [Theory, AutoData]
    public async Task Serialize(string value, CancellationTokenSource cts, Mock<IJson> json)
    {
        var q = from x in Json<RT>.SerializeEff(value)
                select x;

        var r = new RT(cts, json.Object);
    }

    [Theory, AutoData]
    public void Deserialize(CancellationTokenSource cts)
    {
    }
}
