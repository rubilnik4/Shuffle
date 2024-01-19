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
        from createId in CardDeckFManager<TRun>.CreateDeskCard()
        from shuffleId in CardDeckFManager<TRun>.ShuffleDeskCard()
        from showId in CardDeckFManager<TRun>.ShowDeskCard()
        from _ in CardDeckFManager<TRun>.ShowDeskCardNames()
        from deleteId in CardDeckFManager<TRun>.DeleteDeskCard()
        select Unit.Default;
}