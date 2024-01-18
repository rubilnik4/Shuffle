using Shuffle.Common.Models;

namespace Shuffle.OOP.Infrastructure.Cards;

/// <summary>
/// Хранилище игральных колод
/// </summary>
public interface ICardDeckStorage
{
    /// <summary>
    /// Добавить колоду
    /// </summary>
    string AddDesk(CardDeck cardDeck);

    /// <summary>
    /// Обновить колоду
    /// </summary>
    void UpdateDesk(CardDeck cardDeck);

    /// <summary>
    /// Удалить колоду
    /// </summary>
    CardDeck DeleteDesk(string cardName);

    /// <summary>
    /// Список наименований колод
    /// </summary>
    IReadOnlyCollection<string> GetCardDeskNames();

    /// <summary>
    /// Найти колоду
    /// </summary>
    CardDeck GetCardDesk(string cardName);
}