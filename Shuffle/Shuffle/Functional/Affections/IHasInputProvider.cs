using LanguageExt;
using Shuffle.Functional.IO.Common;

namespace Shuffle.Functional.Affections;

/// <summary>
/// Ввод данных
/// </summary>
public interface IHasInputProvider<TRun>
    where TRun : struct
{
    /// <summary>
    /// Ввод данных
    /// </summary>
    Eff<TRun, IInputProviderIO> InputProviderEff { get; }
}