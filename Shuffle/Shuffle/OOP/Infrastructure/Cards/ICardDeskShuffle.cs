using Shuffle.OOP.Models.Cards;

namespace Shuffle.OOP.Infrastructure.Cards;

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