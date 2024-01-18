using System.Collections.Immutable;
using System.ComponentModel;

namespace Shuffle.Common.Models;

/// <summary>
/// Колода карт
/// </summary>
public class CardDeck
{
    public CardDeck(string deckName, IImmutableList<Card> cards)
    {
        DeckName = deckName;
        Cards = cards;
    }

    /// <summary>
    /// Идентификатор колоды
    /// </summary>
    public string DeckName { get; }

    /// <summary>
    /// Карты
    /// </summary>
    public IImmutableList<Card> Cards { get; }
}