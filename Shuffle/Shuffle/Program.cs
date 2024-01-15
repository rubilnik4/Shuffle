// See https://aka.ms/new-console-template for more information

using System.ComponentModel.Design;
using Shuffle.Infrastructure;

var cardShuffle = new CardFisherYatesShuffle();
var cardDeskFactory = new CardDeskFactory(cardShuffle);
var cardDeskStorage = new CardDeckStorage();
var logger = new ConsoleLogger();
var inputProvider = new ConsoleInputProvider();
var cardDeskManager = new CardDeskManager(cardDeskFactory, cardDeskStorage, logger, inputProvider);

int GetActionNumber()
{
    Console.WriteLine("Укажите номер действия");
    var actionNumber = Console.ReadLine();
    return int.Parse(actionNumber ?? String.Empty);
}

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

