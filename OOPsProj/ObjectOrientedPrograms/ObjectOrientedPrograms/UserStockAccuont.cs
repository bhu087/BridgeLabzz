using System;
using System.Collections.Generic;
using System.Text;

namespace ObjectOrientedPrograms
{
    class UserStockAccuont
    {
        public static void UserStockAcc()
        {
            Utility userUtility = new Utility();
            Console.WriteLine("1 For Create Account\n2 for Delete your Account");
            Console.WriteLine("3 for Display your Report\n4 for Purshase share");
            Console.WriteLine("5 for sell your\n6 total shares you have");
            Console.WriteLine("7 total amount you have");
            int option = userUtility.IntInput();
            switch (option)
            {
                case 1:
                    userUtility.StockAccount();
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    break;
                case 7:
                    break;
                default:
                    break;
            }
        }
    }
}
