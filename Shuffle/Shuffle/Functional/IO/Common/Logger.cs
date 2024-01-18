using LanguageExt;
using LanguageExt.SomeHelp;
using Shuffle.Functional.Affections;

namespace Shuffle.Functional.IO.Common;

/// <summary>
/// Логгер
/// </summary>
public static class Logger<TRun>
    where TRun: struct, IHasLogger<TRun>
{
    /// <summary>
    /// Записать строку
    /// </summary>
    public static Eff<TRun, Unit> Log(string value) =>
        default(TRun).LoggerEff.Map(logger => logger.Log(value));
}