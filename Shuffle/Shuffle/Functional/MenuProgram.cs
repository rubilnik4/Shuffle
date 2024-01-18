using LanguageExt;
using Shuffle.Functional.Affections;
using Shuffle.Functional.Cards;

namespace Shuffle.Functional;

/// <summary>
/// Старт приложения
/// </summary>
public static class MenuProgram<TRun>
    where TRun : struct, IHasCardDeskStorage<TRun>, IHasLogger<TRun>, IHasInputProvider<TRun>
{
    /// <summary>
    /// Запустить
    /// </summary>
    public static Eff<TRun, Unit> Start() =>
        from cardDeskName in CardDeskCreate<TRun>.CreateDeskCard()
        select Unit.Default;
}