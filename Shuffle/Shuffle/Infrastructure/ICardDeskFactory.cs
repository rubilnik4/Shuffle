using Shuffle.Models;

namespace Shuffle.Infrastructure;

/// <summary>
/// Фабрика карточных колод
/// </summary>
public interface ICardDeskFactory
{
    /// <summary>
    /// Создать колоду определенного типа
    /// </summary>
    CardDeck CreateCardDeck(CardDeckType cardDeckType, string cardDeskName);

    /// <summary>
    /// Перетасовать колоду
    /// </summary>
    CardDeck ShuffleCardDeck(CardDeck cardDeck);
}