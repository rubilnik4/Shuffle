using LanguageExt;
using LanguageExt.ClassInstances.Pred;
using LanguageExt.Common;
using Shuffle.Common.Models;
using Shuffle.Functional.Affections;

namespace Shuffle.Functional.Cards;

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
                           from cardDeckName in AddCardDeckToStorage(cardDeck)
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