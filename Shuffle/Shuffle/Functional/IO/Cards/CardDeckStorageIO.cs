using Shuffle.Common.Models;
using Shuffle.OOP.Infrastructure.Cards;
using System.Data;
using LanguageExt;
using LanguageExt.Common;
using System.Collections.Generic;

namespace Shuffle.Functional.IO.Cards;

/// <summary>
/// Хранилище игральных колод
/// </summary>
public class CardDeckStorageIO : ICardDeskStorageIO
{
    /// <summary>
    /// Карточные колоды
    /// </summary>
    private readonly IDictionary<string, CardDeck> _cardDesks = new Dictionary<string, CardDeck>();

    /// <summary>
    /// Добавить колоду
    /// </summary>
    public Validation<Error, string> AddCardDeck(CardDeck cardDeck)
    {
        if (_cardDesks.ContainsKey(cardDeck.DeckName))
            return Error.New(new DuplicateNameException($"Колода {cardDeck.DeckName} уже существует"));

        _cardDesks.Add(cardDeck.DeckName, cardDeck);
        return cardDeck.DeckName;
    }

    /// <summary>
    /// Получить колоду
    /// </summary>
    public Validation<Error, CardDeck> GetCardDeck(string cardDeckName) =>
        _cardDesks.TryGetValue(cardDeckName)
            .ToValidation(Error.New($"Колода {cardDeckName} не найдена"));

    /// <summary>
    /// Обновить колоду
    /// </summary>
    public Validation<Error, Unit> UpdateCardDeck(CardDeck cardDeck)
    {
        if (!_cardDesks.ContainsKey(cardDeck.DeckName))
            return Error.New(new KeyNotFoundException($"Колода {cardDeck.DeckName} не найдена"));

        _cardDesks[cardDeck.DeckName] = cardDeck;
        return Unit.Default;
    }

    /// <summary>
    /// Обновить колоду
    /// </summary>
    public Validation<Error, CardDeck> DeleteCardDeck(string cardDeckName)
    {
        if (!_cardDesks.ContainsKey(cardDeckName))
            return Error.New(new KeyNotFoundException($"Колода {cardDeckName} не найдена"));

        var cardDeck = _cardDesks[cardDeckName];
        _cardDesks.Remove(cardDeckName);
        return cardDeck;
    }

    /// <summary>
    /// Список наименований колод
    /// </summary>
    public Seq<string> GetCardDeskNames() =>
        _cardDesks.Keys.ToSeq();
}