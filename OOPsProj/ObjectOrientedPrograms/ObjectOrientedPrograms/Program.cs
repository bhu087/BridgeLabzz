using System;

namespace ObjectOrientedPrograms
{
    class Program
    {
        static void Main(string[] args)
        {
            Utility MainUtility = new Utility();
            Console.WriteLine("Hello welcome to OOPs\n1 for Inventry Data Management");
            Console.WriteLine("2 for Stoke Account Management");
            Console.WriteLine("......................................................");
            int option = MainUtility.IntInput();
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
