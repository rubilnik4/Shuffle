using LanguageExt;
using LanguageExt.Common;
using Shuffle.Common.Models;

namespace Shuffle.Functional.Cards;

/// <summary>
/// Хранилище игральных колод
/// </summary>
public interface ICardDeskFStorage
{
    /// <summary>
    /// Добавить колоду
    /// </summary>
    Validation<Error, string> AddDesk(CardDeck cardDeck);
}