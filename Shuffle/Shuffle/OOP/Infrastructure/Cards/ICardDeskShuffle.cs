using Shuffle.Common.Models;

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