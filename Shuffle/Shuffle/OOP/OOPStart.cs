using Shuffle.OOP.Infrastructure.Cards;
using Shuffle.OOP.Infrastructure.Common;

namespace Shuffle.OOP;

/// <summary>
/// ООП старт
/// </summary>
public static class OOPStart
{
    public static void Start()
    {
        var cardShuffle = new CardFisherYatesShuffle();
        var cardDeskFactory = new CardDeckFactory(cardShuffle);
        var cardDeskStorage = new CardDeckStorage();
        var logger = new ConsoleLogger();
        var inputProvider = new ConsoleInputProvider();
        var cardDeskManager = new CardDeckManager(cardDeskFactory, cardDeskStorage, logger, inputProvider);
        Action(cardDeskManager, logger);
    }

    /// <summary>
    /// Выбрать действие
    /// </summary>
    private static void Action(ICardDeskManager cardDeskManager, ILogger logger)
    {
        var continueValue = true;
        while (continueValue)
        {
            var actionNumber = GetActionNumber();
            try
            {
                switch (actionNumber)
                {
                    case 1:
                        cardDeskManager.CreateDesk();
                        break;
                    case 2:
                        cardDeskManager.ShuffleDesk();
                        break;
                    case 3:
                        cardDeskManager.DeleteDesk();
                        break;
                    case 4:
                        cardDeskManager.ShowCardDeskNames();
                        break;
                    case 5:
                        cardDeskManager.ShowCardDesk();
                        break;
                    default:
                        continueValue = false;
                        break;
                }
            }
            catch (Exception e)
            {
                logger.Log(e.Message);
            }
        }
    }

    private static int GetActionNumber()
    {
        Console.WriteLine("Укажите номер действия");
        var actionNumber = Console.ReadLine();
        return int.Parse(actionNumber ?? String.Empty);
    }
}