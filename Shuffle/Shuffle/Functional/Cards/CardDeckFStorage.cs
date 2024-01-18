using Shuffle.Common.Models;
using Shuffle.OOP.Infrastructure.Cards;
using System.Data;
using LanguageExt;
using LanguageExt.Common;

namespace Shuffle.Functional.Cards;

/// <summary>
/// Хранилище игральных колод
/// </summary>
public class CardDeckFStorage : ICardDeskFStorage
{
    /// <summary>
    /// Карточные колоды
    /// </summary>
    private readonly Dictionary<string, CardDeck> _cardDesks = new();

    /// <summary>
    /// Добавить колоду
    /// </summary>
    public Validation<Error, string> AddDesk(CardDeck cardDeck)
    {
        if (_cardDesks.ContainsKey(cardDeck.DeckName))
            return Error.New(new DuplicateNameException($"Card desk {cardDeck.DeckName} already exist"));

        _cardDesks.Add(cardDeck.DeckName, cardDeck);
        return cardDeck.DeckName;
    }
}