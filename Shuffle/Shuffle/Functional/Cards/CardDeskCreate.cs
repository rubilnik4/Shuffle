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
    where TRun : struct, IHasCardDeskStorage<TRun>, IHasLogger<TRun>
{
    /// <summary>
    /// Инициализировать колоду
    /// </summary>
    public static Eff<TRun, string> CreateDeskCard()
    {
        var cardDeskName = from cardDeck in CreteCardDeck()
                           from _1 in Logger<TRun>.Log($"Создана колода {cardDeck.DeckName}")
                           from cardDeckName in AddCardDeckToStorage(cardDeck)
                           from _2 in Logger<TRun>.Log($"Колода {cardDeck.DeckName} записана в базу")
                           select cardDeckName;
        return cardDeskName;
    }

    /// <summary>
    /// Создать карточную колоду
    /// </summary>
    private static Eff<TRun, CardDeck> CreteCardDeck() =>
        CardDeskFFactory.CreateCardDeck(CardDeckType.Standard52, "Хуй")
            .ToEff(errors => errors.First());

    /// <summary>
    /// Добавить в базу колоду
    /// </summary>
    private static Eff<TRun, string> AddCardDeckToStorage(CardDeck cardDeck) =>
        default(TRun).CardDeskStorageEff
            .Bind(storage => storage.AddDesk(cardDeck)
                      .ToEff(errors => errors.First()));
}