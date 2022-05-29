using Cff.Effect.Abstractions;

namespace Cff.Effect;

public static class Logging<RT> where RT : struct, HasLoggingAbstract<RT>
{
    public static Eff<RT, Unit> InfoEff(string message, params object?[] args) =>
        default(RT).LoggingEff.Map(rt => rt.Info(message, args));

    public static Eff<RT, Unit> ErrorEff(Exception ex) =>
        default(RT).LoggingEff.Map(rt => rt.Error(ex, string.Empty));

    public static Eff<RT, Unit> ErrorEff(Error error) =>
        default(RT).LoggingEff.Map(rt => rt.Error(error, string.Empty));
}
