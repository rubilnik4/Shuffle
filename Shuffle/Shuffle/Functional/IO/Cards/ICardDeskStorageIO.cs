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
    Validation<Error, string> AddDesk(CardDeck cardDeck);
}