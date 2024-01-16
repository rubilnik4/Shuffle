using Shuffle.Models;

namespace Shuffle.Infrastructure.Cards;

/// <summary>
/// Управление колодой
/// </summary>
public interface ICardDeskManager
{
    /// <summary>
    /// Создать колоду
    /// </summary>
    void CreateDesk();

    /// <summary>
    /// Перетасовать колоду
    /// </summary>
    void ShuffleDesk();

    /// <summary>
    /// Удалить колоду
    /// </summary>
    void DeleteDesk();

    /// <summary>
    /// Отобразить список наименований колод
    /// </summary>
    void ShowCardDeskNames();

    /// <summary>
    /// Отобразить колоду
    /// </summary>
    void ShowCardDesk();
}