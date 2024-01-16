using Shuffle.Infrastructure.Common;
using Shuffle.Models.Cards;

namespace Shuffle.Infrastructure.Cards;

/// <summary>
/// Управление колодой
/// </summary>
public class CardDeskManager : ICardDeskManager
{
    public CardDeskManager(ICardDeskFactory cardDeskFactory, ICardDeckStorage cardDeckStorage,
                           ILogger logger, IInputProvider inputProvider)
    {
        _cardDeskFactory = cardDeskFactory;
        _cardDeckStorage = cardDeckStorage;
        _logger = logger;
        _inputProvider = inputProvider;
    }

    /// <summary>
    /// Фабрика карточных колод
    /// </summary>
    private readonly ICardDeskFactory _cardDeskFactory;

    /// <summary>
    /// Хранилище игральных колод
    /// </summary>
    private readonly ICardDeckStorage _cardDeckStorage;

    /// <summary>
    /// Логгер
    /// </summary>
    private readonly ILogger _logger;

    /// <summary>
    /// Ввод данных
    /// </summary>
    private readonly IInputProvider _inputProvider;

    /// <summary>
    /// Создать колоду
    /// </summary>
    public void CreateDesk()
    {
        var cardDeskName = _inputProvider.GetValue("Введите название колоды");
        if (string.IsNullOrEmpty(cardDeskName))
            throw new ArgumentNullException(nameof(cardDeskName));

        _logger.Log($"Создание колоды {cardDeskName}");
        var cardDesk = _cardDeskFactory.CreateCardDeck(CardDeckType.Standard36, cardDeskName);

        _logger.Log($"Добавление колоды {cardDeskName} в базу");
        _cardDeckStorage.AddDesk(cardDesk);
    }

    /// <summary>
    /// Перетасовать колоду
    /// </summary>
    public void ShuffleDesk()
    {
        var cardDeskName = _inputProvider.GetValue("Введите название колоды");
        if (string.IsNullOrEmpty(cardDeskName))
            throw new ArgumentNullException(nameof(cardDeskName));

        _logger.Log($"Получение колоды {cardDeskName}");
        var cardDesk = _cardDeckStorage.GetCardDesk(cardDeskName);

        _logger.Log($"Перетасовка колоды {cardDeskName}");
        var shuffledDesk = _cardDeskFactory.ShuffleCardDeck(cardDesk);

        _logger.Log($"Обновление колоды {shuffledDesk.DeckName}");
        _cardDeckStorage.UpdateDesk(shuffledDesk);
    }

    /// <summary>
    /// Удалить колоду
    /// </summary>
    public void DeleteDesk()
    {
        var cardDeskName = _inputProvider.GetValue("Введите название колоды");
        if (string.IsNullOrEmpty(cardDeskName))
            throw new ArgumentNullException(nameof(cardDeskName));

        _logger.Log($"Удаление колоды {cardDeskName}");
        _cardDeckStorage.DeleteDesk(cardDeskName);
    }

    /// <summary>
    /// Отобразить список наименований колод
    /// </summary>
    public void ShowCardDeskNames()
    {
        var cardDeskNames = _cardDeckStorage.GetCardDeskNames();
        foreach (var cardDeskName in cardDeskNames)
        {
            _logger.Log(cardDeskName);
        }
    }

    /// <summary>
    /// Отобразить колоду
    /// </summary>
    public void ShowCardDesk()
    {
        var cardDeskName = _inputProvider.GetValue("Введите название колоды");
        if (string.IsNullOrEmpty(cardDeskName))
            throw new ArgumentNullException(nameof(cardDeskName));

        var cardDesk = _cardDeckStorage.GetCardDesk(cardDeskName);
        _logger.Log($"Найдена колода: {cardDesk.DeckName}");
    }
}