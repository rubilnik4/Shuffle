using Shuffle.Models.Cards;

namespace Shuffle.Infrastructure.Cards;

/// <summary>
/// Перетасовка карт
/// </summary>
public interface ICardShuffle
{
    /// <summary>
    /// Перетасовать карты
    /// </summary>
    IReadOnlyList<Card> Shuffle(IReadOnlyList<Card> cards);
}