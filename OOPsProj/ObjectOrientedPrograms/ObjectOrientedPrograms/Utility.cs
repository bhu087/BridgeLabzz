////.............................
////<copyright file="Utility.cs" company="BridgeLabz">
//// author="Bhushan"
//// </copyright>
////.............................
namespace ObjectOrientedPrograms
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// This is the utility class for OOPs project
    /// </summary>
    public class Utility
    {
        /// <summary>
        /// The text format
        /// </summary>
        private static string jsonText = File.ReadAllText(@"D:\BridgeLabzBhush\ObjectOrientedPrograms\ObjectOrientedPrograms\ItemsList.json");

        /// <summary>
        /// input for.
        /// </summary>
        /// <returns>Integer value</returns>
        public int IntInput()
        {
            try 
            {
                int input = int.Parse(Console.ReadLine());
                return input;
            }
            catch (Exception)
            {
                Console.WriteLine("You are entered invalid entry\nTry again...");
                this.IntInput();
                return default;
            }
        }

        /// <summary>
        /// input for floats.
        /// </summary>
        /// <returns>Float value</returns>
        public float DoubleInput()
        {
            try
            {
                float input = (float)double.Parse(Console.ReadLine());
                return input;
            }
            catch (Exception)
            {
                Console.WriteLine("You are entered invalid entry\nTry again...");
                this.DoubleInput();
                return default;
            }
        }

        /// <summary>
        /// Deserialize the item.
        /// </summary>
        /// <returns>returns Items list</returns>
        public Items DeserealizeItem()
        {
            Items deserializedItem = JsonConvert.DeserializeObject<Items>(jsonText);
            return deserializedItem;
        }

        /// <summary>
        /// Prints the item information.
        /// </summary>
        /// <param name="item">The item.</param>
        public void PrintItemInfo(List<ItemInfo> item)
        {
            foreach (ItemInfo listData in item)
            {
                Console.WriteLine("{0} {1} {2}", listData.Name, listData.Weight, listData.Rate);
            }
        }

        /// <summary>
        /// Selects the name of the item.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>returns integer</returns>
        public int SelectItemByName(string name)
        {
            ////in this product1 t 3 are taken for displaying the Names
            JObject parseObj = JObject.Parse(jsonText);
            var product1 = parseObj[name][0];
            var product2 = parseObj[name][1];
            var product3 = parseObj[name][2];
            Console.WriteLine("0 for {0}\n1 for {1}\n2 for {2}", product1["Name"], product2["Name"], product3["Name"]);
            int option = this.IntInput();
            return option;
        }

        /// <summary>
        /// Selects the name of the item content.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="option">The option.</param>
        /// <returns>returns integer value</returns>
        public int SelectInfoByName(string name, int option)
        {
            ////Here we taking the contents of the perticular item
            JObject parseObj = JObject.Parse(jsonText);
            var product = parseObj[name][option];
            Console.WriteLine("0 for update Name : {0}", product["Name"]);
            Console.WriteLine("1 for update Name : {0}", product["Weight"]);
            Console.WriteLine("2 for update Name : {0}", product["Rate"]);
            option = this.IntInput();
            return option;
        }

        /// <summary>
        /// Update the file here.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="index">The index.</param>
        /// <param name="contentIndex">Index of the content.</param> 
        public void UpdateHere(string name, int index, int contentIndex)
        {
            string property = string.Empty;
            dynamic dyn = JsonConvert.DeserializeObject(jsonText);
            ////Here index is denotes the which item in the list
            ////And content denotes the which element of the item
            if (index == 0)
            {
                if (contentIndex == 0)
                {
                    property = "Name";
                    Console.WriteLine("Enter new Name");
                    dyn[name][index][property] = Console.ReadLine();
                }

                if (contentIndex == 1)
                {
                    property = "Weight";
                    Console.WriteLine("Enter new Weight");
                    dyn[name][index][property] = this.IntInput();
                }

                if (contentIndex == 2)
                {
                    property = "Rate";
                    Console.WriteLine("Enter new Rate");
                    dyn[name][index][property] = this.DoubleInput();
                }
            }

            if (index == 1)
            {
                if (contentIndex == 0)
                {
                    property = "Name";
                    Console.WriteLine("Enter new Name");
                    dyn[name][index][property] = Console.ReadLine();
                }

                if (contentIndex == 1)
                {
                    property = "Weight";
                    Console.WriteLine("Enter new Weight");
                    dyn[name][index][property] = this.IntInput();
                }

                if (contentIndex == 2)
                {
                    property = "Rate";
                    Console.WriteLine("Enter new Rate");
                    dyn[name][index][property] = this.DoubleInput();
                }
            }

            if (index == 2)
            {
                if (contentIndex == 0)
                {
                    property = "Name";
                    Console.WriteLine("Enter new Name");
                    dyn[name][index][property] = Console.ReadLine();
                }

                if (contentIndex == 1)
                {
                    property = "Weight";
                    Console.WriteLine("Enter new Weight");
                    dyn[name][index][property] = this.IntInput();
                }

                if (contentIndex == 2)
                {
                    property = "Rate";
                    Console.WriteLine("Enter new Rate");
                    dyn[name][index][property] = this.DoubleInput();
                }
            }
            ////here we need to write back all the contents to json file
            string output = JsonConvert.SerializeObject(dyn, Formatting.Indented);
            File.WriteAllText(@"D:\BridgeLabzBhush\ObjectOrientedPrograms\ObjectOrientedPrograms\ItemsList.json", output);
        }
        ///////////////////////////////////////////// STOCK UTILITY /////////////////////////// 
        
        /// <summary>
        /// Displays the stock.
        /// </summary>
        /// <param name="stockList">The stock list.</param>
        public void DisplayStoke(List<StockObject> stockList)
        {
            ////List<StockObject> stockListObject = stockList;
            foreach (StockObject stockData in stockList)
            {
                Console.WriteLine("{0} Company have {1} shares and share price is {2}", stockData.StockName, stockData.NumberOfShare, stockData.SharePrice);
            }
        }

        /// <summary>
        /// Total stocks.
        /// </summary>
        /// <param name="stockList">The stock list.</param>
        public void TotalStocks(List<StockObject> stockList)
        {
            int totalStockValue = 0;
            foreach (StockObject stockData in stockList)
            {
                totalStockValue += stockData.NumberOfShare * stockData.SharePrice;
            }

            Console.WriteLine("Total Stock available is {0}", totalStockValue);
        }

        /// <summary>
        /// Total shares.
        /// </summary>
        /// <param name="stockList">The stock list.</param>
        public void TotalShares(List<StockObject> stockList)
        {
            int totalStockValue = 0;
            foreach (StockObject stockData in stockList)
            {
                totalStockValue += stockData.NumberOfShare;
            }

            Console.WriteLine("Total Stock available is {0}", totalStockValue);
        }

        /// <summary>
        /// Stock company names.
        /// </summary>
        /// <param name="stockList">The stock list.</param>
        public void StockCompanyNames(List<StockObject> stockList)
        {
            foreach (StockObject stockData in stockList)
            {
                Console.WriteLine(stockData.StockName);
            }
        }

        /// <summary>
        /// particular company details.
        /// </summary>
        /// <param name="stockList">The stock list.</param>
        public void StockCompany(List<StockObject> stockList)
        {
            int i = 0;
            foreach (StockObject stockObjectValue in stockList)
            {
                Console.WriteLine("{0} for {1}", i, stockObjectValue.StockName);
                i++;
            }

            int option = this.IntInput();
            Console.WriteLine("Company \t:{0} ", stockList[option].StockName);
            Console.WriteLine("Shares \t\t:{0} ", stockList[option].NumberOfShare);
            Console.WriteLine("Share Price \t:{0} ", stockList[option].SharePrice);
        }
        /////////////////////////////////////////////////////////////////////////////
        public MyLinkedList<string> suitInitialization(MyLinkedList<string> myLinkedList)
        {
            myLinkedList.Add("Clubs");
            myLinkedList.Add("Diamonds");
            myLinkedList.Add("Hearts");
            myLinkedList.Add("Spades");
            return myLinkedList;
        }
        public MyLinkedList<string> rankInitialization(MyLinkedList<string> myLinkedList)
        {
            myLinkedList.Add("2");
            myLinkedList.Add("3");
            myLinkedList.Add("4");
            myLinkedList.Add("5");
            myLinkedList.Add("6");
            myLinkedList.Add("7");
            myLinkedList.Add("8");
            myLinkedList.Add("9");
            myLinkedList.Add("10");
            myLinkedList.Add("Jack");
            myLinkedList.Add("Diamond");
            myLinkedList.Add("Heart");
            myLinkedList.Add("Spade");
            return myLinkedList;
        }
        public MyLinkedList<int> MaxCardInitialization(MyLinkedList<int> myLinkedList)
        {
            myLinkedList.Add(4);
            myLinkedList.Add(4);
            myLinkedList.Add(4);
            myLinkedList.Add(4);
            myLinkedList.Add(4);
            myLinkedList.Add(4);
            myLinkedList.Add(4);
            myLinkedList.Add(4);
            myLinkedList.Add(4);
            myLinkedList.Add(4);
            myLinkedList.Add(4);
            myLinkedList.Add(4);
            myLinkedList.Add(4);
            return myLinkedList;
        }
        public MyLinkedList<int> MaxSuitInitialization(MyLinkedList<int> myLinkedList)
        {
            myLinkedList.Add(13);
            myLinkedList.Add(13);
            myLinkedList.Add(13);
            myLinkedList.Add(13);
            return myLinkedList;
        }
    }
}
