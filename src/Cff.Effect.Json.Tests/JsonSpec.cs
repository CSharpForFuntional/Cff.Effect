using AutoFixture.Xunit2;

namespace Cff.Effect.Json.Tests;

public class JsonSpec
{
    [Theory, AutoData]
    public void Serialize(string value)
    {
        var sut = new Json(default);
        var ret = sut.Serialize(value);

        Assert.Equal($"{{\"A\":\"System.Private.CoreLib\",\"T\":\"System.String\",\"V\":\"{value}\"}}", ret);
    }
}
