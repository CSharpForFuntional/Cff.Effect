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
    public void Serialize(string value, CancellationTokenSource cts, Mock<IJson> json)
    {
        _ = json.Setup(x => x.Serialize(It.IsAny<string>()))
                .Returns(() => "1");

        var q = Json<RT>.SerializeEff(value);
        var r = q.Run(new RT(cts, json.Object));

        Assert.Equal("1", r.ThrowIfFail());
    }
}
