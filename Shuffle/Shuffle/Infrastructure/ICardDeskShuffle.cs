using Shuffle.Models;

namespace Shuffle.Infrastructure;

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