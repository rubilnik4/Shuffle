using LanguageExt;
using Shuffle.Common.Models;
using Shuffle.Functional.Affections;

namespace Shuffle.Functional.IO.Cards;

/// <summary>
/// Хранилище игральных колод
/// </summary>
public static class CardDeckStorage<TRun>
    where TRun : struct, IHasCardDeskStorage<TRun>
{
    /// <summary>
    /// Добавить в базу колоду
    /// </summary>
    public static Eff<TRun, string> AddCardDeck(CardDeck cardDeck) =>
        default(TRun).CardDeskStorageEff
            .Bind(storage => storage.AddCardDeck(cardDeck)
                      .ToEff(errors => errors.First()));

    /// <summary>
    /// Получить колоду из базы
    /// </summary>
    public static Eff<TRun, CardDeck> GetCardDeck(string cardDeckName) =>
        default(TRun).CardDeskStorageEff
            .Bind(storage => storage.GetCardDeck(cardDeckName)
                      .ToEff(errors => errors.First()));

    /// <summary>
    /// Обновить колоду в базе
    /// </summary>
    public static Eff<TRun, Unit> UpdateCardDeck(CardDeck cardDeck) =>
        default(TRun).CardDeskStorageEff
            .Bind(storage => storage.UpdateCardDeck(cardDeck)
                      .ToEff(errors => errors.First()));

    /// <summary>
    /// Обновить колоду в базе
    /// </summary>
    public static Eff<TRun, CardDeck> DeleteCardDeck(string cardDeckName) =>
        default(TRun).CardDeskStorageEff
            .Bind(storage => storage.DeleteCardDeck(cardDeckName)
                      .ToEff(errors => errors.First()));
}