using System.Collections.Immutable;
using LanguageExt;
using LanguageExt.Common;
using Shuffle.Common.Models;
using Shuffle.OOP.Infrastructure.Cards;

namespace Shuffle.Functional.Cards;

/// <summary>
/// Создание колоды
/// </summary>
public static class CardDeckFFactory
{
    /// <summary>
    /// Создать колоду определенного типа
    /// </summary>
    public static Validation<Error, CardDeck> CreateCardDeck(CardDeckType cardDeckType, string cardDeckName) =>
        cardDeckType switch
        {
            CardDeckType.Standard36 => GetDeck32(cardDeckName),
            CardDeckType.Standard52 => GetDeck52(cardDeckName),
            _ => Error.New(new ArgumentOutOfRangeException(nameof(cardDeckType), cardDeckType, null))
        };

    /// <summary>
    /// Получить колоду на 52 карты
    /// </summary>
    private static CardDeck GetDeck52(string deckName)
    {
        var cards = Enum
            .GetValues<CardRankType>()
            .SelectMany(cardType => Enum.GetValues<CardSuitType>().Select(suitType => new Card(cardType, suitType)))
            .ToImmutableList();
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
            .ToImmutableList();
        return new CardDeck(deckName, cards);
    }
}