using Shuffle.Common.Models;

namespace Shuffle.Functional.Cards;

/// <summary>
/// Алгоритмы перетасовки
/// </summary>
public static class CardDeckShuffleAlgorithm
{
    /// <summary>
    /// Перетасовать карты по алгоритму Фишера
    /// </summary>
    public static IReadOnlyList<Card> FisherYatesShuffle(IReadOnlyList<Card> cards)
    {
        var cardsShuffled = new Card[cards.Count];
        var randomizer = new Random();
        for (var i = 0; i < cards.Count; i++)
        {
            var index = randomizer.Next(0, i);
            cardsShuffled[i] = cardsShuffled[index];
            cardsShuffled[index] = cards[i];
        }

        return cardsShuffled.AsReadOnly();
    }
}