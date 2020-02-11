
namespace ObjectOrientedPrograms
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class StockAccount
    {
        public static void UserStockAccount()
        {
            Utility stockUtility = new Utility();
            Console.WriteLine("Welcome to Commercial data processing");
            Console.WriteLine("1 for create an Account\n2 for total value of your Account");
            Console.WriteLine("3 for buy a share\n4 for sell a share\n5 for your Account report");
            int option = stockUtility.IntInput();
            switch (option)
            {
                case 1:
                    stockUtility.StockAccount();
                    break;
                case 2:
                    string name = Console.ReadLine();
                    stockUtility.ValueOf(name);
                    break;
                case 3:
                    stockUtility.BuyAShare();
                    break;
                case 4:
                    stockUtility.SellAShare();
                    break;
                case 5:
                    stockUtility.Report();
                    break;
                default:
                    Console.WriteLine("Invalid options");
                    return;
            }
        }
    }
}
