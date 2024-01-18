using LanguageExt;
using LanguageExt.ClassInstances.Pred;
using Shuffle.Functional.Affections;
using Shuffle.Functional.IO.Cards;
using Shuffle.Functional.IO.Common;

namespace Shuffle.Functional;
public readonly struct CardRuntime: 
    IHasCardDeskStorage<CardRuntime>, IHasLogger<CardRuntime>
{
    public CardRuntime(ICardDeskStorageIO cardDeskStorageIO, ILoggerIO loggerIO)
    {
        _cardDeskStorageIO = cardDeskStorageIO;
        _loggerIO = loggerIO;
    }

    /// <summary>
    /// Хранилище игральных колод
    /// </summary>
    private readonly ICardDeskStorageIO _cardDeskStorageIO;

    /// <summary>
    /// Логгер
    /// </summary>
    private readonly ILoggerIO _loggerIO;

    /// <summary>
    /// Хранилище карт
    /// </summary>
    public Eff<CardRuntime, ICardDeskStorageIO> CardDeskStorageEff =>
        Prelude.Eff<CardRuntime, ICardDeskStorageIO>(rt => rt._cardDeskStorageIO);

    /// <summary>
    /// Логгер
    /// </summary>
    public Eff<CardRuntime, ILoggerIO> LoggerEff =>
        Prelude.Eff<CardRuntime, ILoggerIO>(rt => rt._loggerIO);
}