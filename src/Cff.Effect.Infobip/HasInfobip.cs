using Cff.Effect.Abstractions;
using Infobip.Api.Client;
using Infobip.Api.Client.Api;

namespace Cff.Effect.Infobip;

public interface HasInfobipEmail<RT> : HasInfobipEmailAbstract<RT>
     where RT : struct, HasInfobipEmail<RT>
{
    Configuration Configuration { get; }
    SendEmailApi SendEmailApi { get; }
    Eff<RT, IInfobip> HasInfobipEmailAbstract<RT>.InfobipEmailEff => Eff<RT, IInfobip>(rt => new InfobipEmail(SendEmailApi));
}
