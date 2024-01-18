using LanguageExt.ClassInstances.Pred;
using LanguageExt;
using LanguageExt.Common;
using Shuffle.Functional.Affections;

namespace Shuffle.Functional.IO.Common;

/// <summary>
/// Ввод данных
/// </summary>
public static class InputProvider<TRun>
    where TRun : struct, IHasInputProvider<TRun>
{
    /// <summary>
    /// Записать строку
    /// </summary>
    public static Eff<TRun, string> GetValue(string question) =>
        default(TRun).InputProviderEff
            .Bind(provider => provider.GetValue(question)
                      .ToEff(Error.New("Значение параметра не указано")));
}