using Cff.Effect.Abstractions;

namespace Cff.Effect;

public static class Logging<RT> where RT : struct, HasLoggingAbstract<RT>
{
    public static Eff<RT, Unit> Info(string message, params object?[] args) =>
        default(RT).LoggingEff.Map(rt => rt.Info(message, args));


}
