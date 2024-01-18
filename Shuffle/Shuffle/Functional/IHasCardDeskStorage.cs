using LanguageExt;

namespace Shuffle.Functional;

/// <summary>
/// Тип класс для получения хранилища карт
/// </summary>
/// <typeparam name="RT"></typeparam>
public interface IHasCardDeskStorage<RT>
    where RT : struct
{
    /// <summary>
    /// Хранилище карт
    /// </summary>
    Eff<RT, ICardDeskFStorage> CardDeskStorageEff { get; }
}