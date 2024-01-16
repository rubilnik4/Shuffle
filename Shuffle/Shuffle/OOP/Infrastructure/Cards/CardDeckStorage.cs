using System.Data;
using Shuffle.OOP.Models.Cards;

namespace Shuffle.OOP.Infrastructure.Cards;

/// <summary>
/// Хранилище игральных колод
/// </summary>
public class CardDeckStorage : ICardDeckStorage
{
    /// <summary>
    /// Карточные колоды
    /// </summary>
    private readonly Dictionary<string, CardDeck> _cardDesks = new();

    /// <summary>
    /// Добавить колоду
    /// </summary>
    public string AddDesk(CardDeck cardDeck)
    {
        if (_cardDesks.ContainsKey(cardDeck.DeckName))
            throw new DuplicateNameException($"Card desk {cardDeck.DeckName} already exist");

        _cardDesks.Add(cardDeck.DeckName, cardDeck);
        return cardDeck.DeckName;
    }

    /// <summary>
    /// Обновить колоду
    /// </summary>
    public void UpdateDesk(CardDeck cardDeck)
    {
        if (!_cardDesks.ContainsKey(cardDeck.DeckName))
            throw new KeyNotFoundException($"Card desk {cardDeck.DeckName} not found");

        _cardDesks[cardDeck.DeckName] = cardDeck;
    }

    /// <summary>
    /// Удалить колоду
    /// </summary>
    public CardDeck DeleteDesk(string cardName)
    {
        if (!_cardDesks.ContainsKey(cardName))
            throw new KeyNotFoundException($"Card desk {cardName} not found");

        var removeCardDesk = _cardDesks[cardName];
        _cardDesks.Remove(cardName);
        return removeCardDesk;
    }

    /// <summary>
    /// Список наименований колод
    /// </summary>
    public IReadOnlyCollection<string> GetCardDeskNames() =>
        _cardDesks.Keys;

    /// <summary>
    /// Найти колоду
    /// </summary>
    public CardDeck GetCardDesk(string cardName)
    {
        if (!_cardDesks.ContainsKey(cardName))
            throw new KeyNotFoundException($"Card desk {cardName} not found");

        return _cardDesks[cardName];
    }
}