using LanguageExt.ClassInstances.Pred;
using LanguageExt;
using Shuffle.Functional.IO.Common;

namespace Shuffle.Functional.Affections;

/// <summary>
/// Консоль
/// </summary>
public interface IHasLogger<TRun>
    where TRun : struct
{
    /// <summary>
    /// Консоль
    /// </summary>
    Eff<TRun, ILoggerIO> LoggerEff { get; }
}