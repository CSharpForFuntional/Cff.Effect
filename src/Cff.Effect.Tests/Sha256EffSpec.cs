using AutoFixture.Xunit2;
using Cff.Effect.Abstractions;
using Cff.Effect.Json;
using Cff.Effect.Sha;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Cff.Effect.Tests;

public class Sha256EffSpec
{
    public readonly record struct RT(CancellationTokenSource CancellationTokenSource) :
        HasCancelDefault<RT>,
        HasJson<RT>,
        HasSha256<RT>
    {
    }

    [Theory, AutoData]
    public async Task Serialize(CancellationTokenSource cts!!)
    {
        var host = Host.CreateDefaultBuilder()
                       .ConfigureServices(service =>
                       {
                           service.AddTransient<Func<CancellationTokenSource, RT>>(sp => cts => ActivatorUtilities.CreateInstance<RT>(sp, cts));
                       })
                       .Build();

        await host.StartAsync();

        var value = "1";

        var q = from x in Sha<RT>.SerializeEff(value)
                select x;

        var r = q.Run(host.Services.GetRequiredService<Func<CancellationTokenSource, RT>>()(cts));

        Assert.Equal("ETFGCDKhBUm/9Yv4ceQgS5f/EOLN3lXb/oViHZFXKI0=", r.ThrowIfFail().ToString());

        await host.StopAsync();
    }
}
