using LanguageExt;
using Shuffle.Functional.IO.Cards;

namespace Shuffle.Functional.Affections;

/// <summary>
/// Тип класс для получения хранилища карт
/// </summary>
public interface IHasCardDeskStorage<TRun>
    where TRun : struct
{
    /// <summary>
    /// Хранилище карт
    /// </summary>
    Eff<TRun, ICardDeskStorageIO> CardDeskStorageEff { get; }
}