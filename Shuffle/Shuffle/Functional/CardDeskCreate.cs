using LanguageExt;
using LanguageExt.ClassInstances.Pred;
using LanguageExt.Common;
using Shuffle.Common.Models;

namespace Shuffle.Functional;

/// <summary>
/// Создание карточной колоды
/// </summary>
public static class CardDeskCreate<TRun>
    where TRun : struct, IHasCardDeskStorage<TRun>
{
    /// <summary>
    /// Инициализировать колоду
    /// </summary>
    public static Eff<TRun, string> CreateDeskCard()
    {
        var cardDeskName = from cardDeck in CreteCardDeck()
                           from card1 in AddCardDeckToStorage(cardDeck)
                           select cardDeck.DeckName;
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