using LanguageExt;
using LanguageExt.Common;
using Shuffle.Common.Models;

namespace Shuffle.Functional.IO.Cards;

/// <summary>
/// Хранилище игральных колод
/// </summary>
public interface ICardDeskStorageIO
{
    /// <summary>
    /// Добавить колоду
    /// </summary>
    Validation<Error, string> AddCardDeck(CardDeck cardDeck);

    /// <summary>
    /// Получить колоду
    /// </summary>
    Validation<Error, CardDeck> GetCardDeck(string cardDeckName);

    /// <summary>
    /// Обновить колоду
    /// </summary>
    Validation<Error, Unit> UpdateCardDeck(CardDeck cardDeck);

    /// <summary>
    /// Обновить колоду
    /// </summary>
    Validation<Error, CardDeck> DeleteCardDeck(string cardDeckName);

    /// <summary>
    /// Список наименований колод
    /// </summary>
    Seq<string> GetCardDeskNames();
}