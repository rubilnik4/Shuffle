using LanguageExt;
using LanguageExt.ClassInstances.Pred;
using LanguageExt.Common;
using Shuffle.Common.Models;
using Shuffle.Functional.Affections;
using Shuffle.Functional.IO.Common;

namespace Shuffle.Functional.Cards;

/// <summary>
/// Создание карточной колоды
/// </summary>
public static class CardDeskCreate<TRun>
    where TRun : struct, IHasCardDeskStorage<TRun>, IHasLogger<TRun>, IHasInputProvider<TRun>
{
    /// <summary>
    /// Инициализировать колоду
    /// </summary>
    public static Eff<TRun, string> CreateDeskCard() =>
        from cardDeckName in InputProvider<TRun>.GetValue("Введите название колоды")
        from cardDeck in CreteCardDeck(cardDeckName)
        from _1 in Logger<TRun>.Log($"Создана колода {cardDeck.DeckName}")
        from addCardDeckName in AddCardDeckToStorage(cardDeck)
        from _2 in Logger<TRun>.Log($"Колода {cardDeck.DeckName} записана в базу")
        select addCardDeckName;

    /// <summary>
    /// Создать карточную колоду
    /// </summary>
    private static Eff<TRun, CardDeck> CreteCardDeck(string cardDeckName) =>
        CardDeskFFactory.CreateCardDeck(CardDeckType.Standard52, cardDeckName)
            .ToEff(errors => errors.First());

    /// <summary>
    /// Добавить в базу колоду
    /// </summary>
    private static Eff<TRun, string> AddCardDeckToStorage(CardDeck cardDeck) =>
        default(TRun).CardDeskStorageEff
            .Bind(storage => storage.AddDesk(cardDeck)
                      .ToEff(errors => errors.First()));
}