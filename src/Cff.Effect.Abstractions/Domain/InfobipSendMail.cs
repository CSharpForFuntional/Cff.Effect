namespace Cff.Effect.Abstractions.Domain;

public record InfobipSendMailRequest(string From,
                                     string To,
                                     string Subject);

public record InfobipSendMailResponse();
