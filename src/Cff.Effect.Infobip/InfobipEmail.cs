using Cff.Effect.Abstractions;
using Cff.Effect.Abstractions.Domain;
using Infobip.Api.Client;
using Infobip.Api.Client.Api;

namespace Cff.Effect.Infobip;


// https://github.com/infobip/infobip-api-csharp-client/blob/master/email.md
public readonly record struct InfobipEmail(SendEmailApi SendEmailApi) : IInfobip
{
    public async Task<InfobipSendMailResponse> SendMail(InfobipSendMailRequest req)
    {
        var ret = await SendEmailApi.SendEmailAsync(req.From, req.To, req.Subject);

        return new InfobipSendMailResponse();

    }
}
