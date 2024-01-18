using LanguageExt;
using LanguageExt.Common;
using Shuffle.Common.Models;

namespace Shuffle.Functional;

/// <summary>
/// Создание карточной колоды
/// </summary>
public static class CardDeskCreate
{
    /// <summary>
    /// Создать карточную колоду
    /// </summary>
    public static Validation<Error, string> CreateDeskCard()
    {
        var cardDeskName = from cardDeck in CardDeskFFactory.CreateCardDeck(CardDeckType.Standard52, "Хуй")
                           select cardDeck.DeckName;
        return cardDeskName;
        }
}