////..........................................
////<copyright file="Program.cs" company="BridgeLabz">
////author="Bhushan"
////</copyright>
////..........................................
namespace ObjectOrientedPrograms
{
    using System;

    /// <summary>
    /// This is the main class for OOPs
    /// </summary>
    public class Program
    {
        /// <summary>
        /// main method.
        /// </summary>
        /// <param name="args">args parameter ID</param>
        public static void Main(string[] args)
        {
            Utility mainUtility = new Utility();
            Console.WriteLine("Hello welcome to OOPs\n1 for Inventry Data Management");
            Console.WriteLine("2 for Stoke Account Management");
            Console.WriteLine("3 for user Stock Account\n4 for Deck Of Cards");
            Console.WriteLine("5 for Deck of cards using List/Queue");
            Console.WriteLine("......................................................");
            int option = mainUtility.IntInput();
            ////Depending on option this will calls the classes.
            switch (option)
            {
                case 1:
                    InventoryDataManagement.DataManagement();
                    break;
                case 2:
                    StockAccountManagement.StokeAccount();
                    break;
                case 3:
                    StockAccount.UserStockAccount();
                    break;
                case 4:
                    DeckOfCards.Deck();
                    break;
                case 5:
                    DeckOfCardsUsingLinkedList dc = new DeckOfCardsUsingLinkedList();
                    dc.DeckOfCardsLinkedList();
                    break;
                default:
                    break;
            }
        }
    }
}
