using LanguageExt;
using Shuffle.Functional.Affections;
using Shuffle.Functional.Cards;

namespace Shuffle.Functional;

public readonly struct CardRuntime: 
    IHasCardDeskStorage<CardRuntime>
{
    public CardRuntime(ICardDeskFStorage cardDeskFStorage)
    {
        _cardDeskFStorage = cardDeskFStorage;
    }

    /// <summary>
    /// Хранилище игральных колод
    /// </summary>
    private readonly ICardDeskFStorage _cardDeskFStorage;

    /// <summary>
    /// Хранилище карт
    /// </summary>
    public Eff<CardRuntime, ICardDeskFStorage> CardDeskStorageEff =>
        Prelude.Eff<CardRuntime, ICardDeskFStorage>(rt => rt._cardDeskFStorage);
}