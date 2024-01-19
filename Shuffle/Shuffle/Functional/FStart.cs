using Shuffle.Functional.IO.Cards;
using Shuffle.Functional.IO.Common;

namespace Shuffle.Functional;

/// <summary>
/// Функциональный старт
/// </summary>
public static class FStart
{
    public static void Start()
    {
        var cardDeckStorageIO = new CardDeckStorageIO();
        var loggerIO = new LoggerIO();
        var inputProviderIO = new InputProviderIO();
        var cardRuntime = new CardRuntime(cardDeckStorageIO, loggerIO, inputProviderIO);
        var eff = MenuProgram<CardRuntime>.Start().Run(cardRuntime);
    }
}