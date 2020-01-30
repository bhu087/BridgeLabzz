﻿using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace ObjectOrientedPrograms
{
    class StockAccountManagement
    {
        public static void StokeAccount()
        {
            Utility stockUtility = new Utility();
            string jsonFileForStock = File.ReadAllText(@"D:\BridgeLabzBhush\ObjectOrientedPrograms\ObjectOrientedPrograms\StockFile.json");
            StockList stockList = JsonConvert.DeserializeObject<StockList>(jsonFileForStock);
            Console.WriteLine("Your are on Stock Account Management");
            Console.WriteLine("1 for Displaying all Stocks\n2 for Total stocks");
            Console.WriteLine("3 for total shares\n4 for Company Names");
            Console.WriteLine("5 for perticular company share");
            int option = stockUtility.IntInput();
            switch (option)
            {
                case 1:
                    stockUtility.DisplayStoke(stockList.Stock);
                    break;
                case 2:
                    stockUtility.TotalStocks(stockList.Stock);
                    break;
                case 3:
                    stockUtility.TotalShares(stockList.Stock);
                    break;
                case 4:
                    stockUtility.StockCompanyNames(stockList.Stock);
                    break;
                case 5:
                    stockUtility.StockCompany(stockList.Stock);
                    break;
                default:
                    Console.WriteLine("You are entered Wrong input\nTry Again...");
                    StokeAccount();
                    break;
            }
        }
    }
}
