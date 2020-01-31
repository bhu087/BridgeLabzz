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
                default:
                    break;
            }
        }
    }
}
