using Shuffle.Models.Cards;

namespace Shuffle.Infrastructure.Cards;

/// <summary>
/// Перетасовка карт
/// </summary>
public class CardFisherYatesShuffle : ICardShuffle
{
    /// <summary>
    /// Перетасовать карты
    /// </summary>
    public IReadOnlyList<Card> Shuffle(IReadOnlyList<Card> cards)
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