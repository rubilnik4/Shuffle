using Shuffle.Common.Models;

namespace Shuffle.OOP.Infrastructure.Cards;

/// <summary>
/// Фабрика карточных колод
/// </summary>
public class CardDeckFactory : ICardDeskFactory
{
    public CardDeckFactory(ICardShuffle cardShuffle)
    {
        _cardShuffle = cardShuffle;
    }

    /// <summary>
    /// Перетасовка карт
    /// </summary>
    private readonly ICardShuffle _cardShuffle;

    /// <summary>
    /// Создать колоду определенного типа
    /// </summary>
    public CardDeck CreateCardDeck(CardDeckType cardDeckType, string cardDeskName) =>
        cardDeckType switch
        {
            CardDeckType.Standard36 => GetDeck32(cardDeskName),
            CardDeckType.Standard52 => GetDeck52(cardDeskName),
            _ => throw new ArgumentOutOfRangeException(nameof(cardDeckType), cardDeckType, null)
        };

    /// <summary>
    /// Перетасовать колоду
    /// </summary>
    public CardDeck ShuffleCardDeck(CardDeck cardDeck)
    {
        var cards = _cardShuffle.Shuffle(cardDeck.Cards);
        return new CardDeck(cardDeck.DeckName, cards);
    }

    /// <summary>
    /// Получить колоду на 52 карты
    /// </summary>
    private static CardDeck GetDeck52(string deckName)
    {
        var cards = Enum
            .GetValues<CardRankType>()
            .SelectMany(cardType => Enum.GetValues<CardSuitType>().Select(suitType => new Card(cardType, suitType)))
            .ToList()
            .AsReadOnly();
        return new CardDeck(deckName, cards);
    }

    /// <summary>
    /// Получить колоду на 32 карты
    /// </summary>
    private static CardDeck GetDeck32(string deckName)
    {
        var exceptCardRanks = new List<CardRankType>()
        {
            CardRankType.Two,
            CardRankType.Three,
            CardRankType.Four,
            CardRankType.Five,
        };
        var cards = GetDeck52(deckName).Cards
            .Where(card => !exceptCardRanks.Contains(card.CardRankType))
            .ToList()
            .AsReadOnly();
        return new CardDeck(deckName, cards);
    }
}