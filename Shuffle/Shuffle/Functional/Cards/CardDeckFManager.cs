using LanguageExt;
using LanguageExt.ClassInstances.Pred;
using LanguageExt.Common;
using Shuffle.Common.Models;
using Shuffle.Functional.Affections;
using Shuffle.Functional.IO.Cards;
using Shuffle.Functional.IO.Common;
using Shuffle.OOP.Infrastructure.Cards;

namespace Shuffle.Functional.Cards;

/// <summary>
/// Создание карточной колоды
/// </summary>
public static class CardDeckFManager<TRun>
    where TRun : struct, IHasCardDeskStorage<TRun>, IHasLogger<TRun>, IHasInputProvider<TRun>
{
    /// <summary>
    /// Инициализировать колоду
    /// </summary>
    public static Eff<TRun, string> CreateDeskCard() =>
        from cardDeckName in InputProvider<TRun>.GetValue("Введите название колоды для создания")
        from cardDeck in CreateCardDeck(cardDeckName)
        from _1 in Logger<TRun>.Log($"Создана колода {cardDeck.DeckName}")
        from addCardDeckName in CardDeckStorage<TRun>.AddCardDeck(cardDeck)
        from _2 in Logger<TRun>.Log($"Колода {cardDeck.DeckName} записана в базу")
        select addCardDeckName;

    /// <summary>
    /// Перетасовать колоду
    /// </summary>
    public static Eff<TRun, string> ShuffleDeskCard() =>
        from cardDeckName in InputProvider<TRun>.GetValue("Введите название колоды для перетасовки")
        from cardDeck in CardDeckStorage<TRun>.GetCardDeck(cardDeckName)
        from _1 in Logger<TRun>.Log($"Получена колода {cardDeck.DeckName}")
        from cardDeckShuffle in ShuffleCardDeck(cardDeck)
        from _2 in Logger<TRun>.Log($"Перетасована колода {cardDeckShuffle.DeckName}")
        from _3 in CardDeckStorage<TRun>.UpdateCardDeck(cardDeckShuffle)
        from _4 in Logger<TRun>.Log($"Колода {cardDeckShuffle.DeckName} обновлена в базе")
        select cardDeckName;

    /// <summary>
    /// Удалить колоду
    /// </summary>
    public static Eff<TRun, string> DeleteDeskCard() =>
        from cardDeckName in InputProvider<TRun>.GetValue("Введите название колоды для удаления")
        from cardDeck in CardDeckStorage<TRun>.DeleteCardDeck(cardDeckName)
        from _2 in Logger<TRun>.Log($"Колода {cardDeck.DeckName} удалена в базе")
        select cardDeck.DeckName;

    /// <summary>
    /// Удалить колоду
    /// </summary>
    public static Eff<TRun, string> ShowDeskCard() =>
        from cardDeckName in InputProvider<TRun>.GetValue("Введите название колоды для просмотра")
        from cardDeck in CardDeckStorage<TRun>.GetCardDeck(cardDeckName)
        from _1 in Logger<TRun>.Log($"Получена колода {cardDeck.DeckName}")
        from _2 in ShowCardDeck(cardDeck)
        select cardDeck.DeckName;

    /// <summary>
    /// Создать карточную колоду
    /// </summary>
    private static Eff<TRun, CardDeck> CreateCardDeck(string cardDeckName) =>
        CardDeckFFactory.CreateCardDeck(CardDeckType.Standard52, cardDeckName)
            .ToEff(errors => errors.First());

    /// <summary>
    /// Перетасовать карточную колоду
    /// </summary>
    private static Eff<TRun, CardDeck> ShuffleCardDeck(CardDeck cardDeck)
    {
        var cards = CardDeckShuffleAlgorithm.FisherYatesShuffle(cardDeck.Cards);
        return Prelude.SuccessEff(new CardDeck(cardDeck.DeckName, cards));
    }

    /// <summary>
    /// Показать карточную колоду
    /// </summary>
    private static Eff<TRun, Unit> ShowCardDeck(CardDeck cardDeck)
    {
        var cardNames = cardDeck.Cards.Select(card => $"{card.CardRankType}-{card.CardSuitType}");
        var name = String.Join("; ", cardNames);
        return Logger<TRun>.Log(name);
    }
}