// See https://aka.ms/new-console-template for more information

using LanguageExt;
using Shuffle.Functional;
using Shuffle.Functional.Cards;
using Shuffle.Functional.IO.Cards;
using Shuffle.Functional.IO.Common;
using Shuffle.OOP.Infrastructure.Cards;
using Shuffle.OOP.Infrastructure.Common;

var cardShuffle = new CardFisherYatesShuffle();
var cardDeskFactory = new CardDeskFactory(cardShuffle);
var cardDeskStorage = new CardDeckStorage();
var logger = new ConsoleLogger();
var inputProvider = new ConsoleInputProvider();
var cardDeskManager = new CardDeskManager(cardDeskFactory, cardDeskStorage, logger, inputProvider);

var cardDeckStorageIO = new CardDeckStorageIO();
var loggerIO = new LoggerIO();
var inputProviderIO = new InputProviderIO();
var cardRuntime = new CardRuntime(cardDeckStorageIO, loggerIO, inputProviderIO);
var eff = MenuProgram<CardRuntime>.Start().Run(cardRuntime);

eff.Match(_ => Console.WriteLine("Success"), 
          error => Console.WriteLine(error.Message));
//int GetActionNumber()
//{
//    Console.WriteLine("Укажите номер действия");
//    var actionNumber = Console.ReadLine();
//    return int.Parse(actionNumber ?? String.Empty);
//}

//var continueValue = true;
//while (continueValue)
//{
//    var actionNumber = GetActionNumber();
//    try
//    {
//        switch (actionNumber)
//        {
//            case 1:
//                cardDeskManager.CreateDesk();
//                break;
//            case 2:
//                cardDeskManager.ShuffleDesk();
//                break;
//            case 3:
//                cardDeskManager.DeleteDesk();
//                break;
//            case 4:
//                cardDeskManager.ShowCardDeskNames();
//                break;
//            case 5:
//                cardDeskManager.ShowCardDesk();
//                break;
//            default:
//                continueValue = false;
//                break;
//        }
//    }
//    catch (Exception e)
//    {
//       logger.Log(e.Message);
//    }
//}

