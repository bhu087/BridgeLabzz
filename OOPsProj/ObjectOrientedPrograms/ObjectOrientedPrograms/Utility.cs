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

        public long LongInput()
        {
            try
            {
                long input = long.Parse(Console.ReadLine());
                return input;
            }
            catch (Exception)
            {
                Console.WriteLine("You are entered invalid entry\nTry again...");
                this.LongInput();
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

        /// <summary>
        /// Sorts the specified my linked list.
        /// </summary>
        /// <param name="mylinkedList">The my linked list.</param>
        /// <returns>my Linked List</returns>
        public MyLinkedList<string> Sort(MyLinkedList<string> mylinkedList)
        {
            int size = mylinkedList.Size();
            string[] s = new string[size];
            for (int i = 0; i < size; i++)
            {
                s[i] = mylinkedList.Pop();
            }

            for (int i = 0; i < size; i++)
            {
                for (int j = i + 1; j < size; j++)
                {
                    char strI = s[i].ToCharArray()[0];
                    char strJ = s[j].ToCharArray()[0];
                    if (strI == '1')
                    {
                        strI = '9';
                    }

                    if (strJ == '1')
                    {
                        strJ = '9';
                    }

                    if (strI.CompareTo(strJ) >= 0)
                    {
                        string tempstring = s[i];
                        s[i] = s[j];
                        s[j] = tempstring;
                    }
                }
            }

            for (int i = 0; i < size; i++)
            {
                mylinkedList.Add(s[i]);
            }

            return mylinkedList;
        }

        /// <summary>
        /// Adds to queue.
        /// </summary>
        /// <param name="myLinkedList">My linked list.</param>
        /// <param name="userNumber">The user number.</param>
        /// <param name="myQueue">My queue.</param>
        /// <returns>my Queue</returns>
        public MyQueue<string> AddToQueue(MyLinkedList<string> myLinkedList, string userNumber, MyQueue<string> myQueue)
        {
            int size = myLinkedList.Size();
            myQueue.AddToQueue(userNumber);
            while (size > 0)
            {
                myQueue.AddToQueue(myLinkedList.PopFirst());
                size--;
            }

            return myQueue;
        }

        /////////////////////////////////////Commercial processessing//////////////////////////////////
        public void StockAccount()
        {
            string jsonFile = File.ReadAllText(@"D:\BridgeLabzBhush\ObjectOrientedPrograms\ObjectOrientedPrograms\StockUsers.json");
            UserList userList = JsonConvert.DeserializeObject<UserList>(jsonFile);
        Name:    Console.WriteLine("Enter your Name");
            string name = Console.ReadLine();
            if (this.DuplicateNames(name))
            {
                Console.WriteLine("This name already exist try anethor");
                goto Name;
            }
            Console.WriteLine("Your Account Number");
            long accNumber = this.LongInput();
            UserObject userObject = new UserObject
            {
                Name = name,
                Savings = 100000,
                CompanyShares = null,
                NumberOfShares = null,
                ShareValue = null
            };
            userList.StockUsers.Add(userObject);
            string output = JsonConvert.SerializeObject(userList,Formatting.Indented);
            File.WriteAllText(@"D:\BridgeLabzBhush\ObjectOrientedPrograms\ObjectOrientedPrograms\StockUsers.json", output);
            Console.WriteLine("Account created successfully");
        }
        public bool DuplicateNames(string name)
        {
            string jsonFile = File.ReadAllText(@"D:\BridgeLabzBhush\ObjectOrientedPrograms\ObjectOrientedPrograms\StockUsers.json");
            UserList userList = JsonConvert.DeserializeObject<UserList>(jsonFile);
            foreach (UserObject userObject in userList.StockUsers)
            {
                if (userObject.Name.Equals(name))
                {
                    return true;
                }
            }
            return false;
        }

        //public void DeleteAccount()
        //{

        //}

        public void ValueOf(string userName)
        {
            string jsonFile = File.ReadAllText(@"D:\BridgeLabzBhush\ObjectOrientedPrograms\ObjectOrientedPrograms\StockUsers.json");
            UserList userList = JsonConvert.DeserializeObject<UserList>(jsonFile);
            JObject jobj = JObject.Parse(jsonFile);
            int i = 0;
            int j = 0;
            int sharesCount = 0;
            int sharePrice = 0;
            int totalMoney = 0;
            try
            {
                foreach (UserObject userObject in userList.StockUsers)
                {
                    if (userObject.Name.Equals(userName))
                    {
                        int jArray = userObject.ShareValue.Count;
                        Console.WriteLine(jArray);
                        while (jArray > 0)
                        {
                            sharesCount = (int)jobj["StockUsers"][i]["NumberOfShares"][j];
                            Console.WriteLine(sharesCount);
                            sharePrice = (int)jobj["StockUsers"][i]["ShareValue"][j];
                            Console.WriteLine(sharePrice);
                            totalMoney += sharesCount * sharePrice;
                            j++;
                            jArray--;
                        }
                        break;
                    }
                    else
                    {
                        i++;
                    }
                }
                Console.WriteLine("Your Total Share Value is {0}", totalMoney);
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Your List Is Empty");
            }
            
        }

        public void BuyAShare()
        {
            string stockFile = File.ReadAllText(@"D:\BridgeLabzBhush\ObjectOrientedPrograms\ObjectOrientedPrograms\StockFile.json");
            StockList stockList = JsonConvert.DeserializeObject<StockList>(stockFile);
            int i = 0;
            ////it asks for which share you want to buy
            foreach (StockObject stockObject in stockList.Stock)
            {
                Console.WriteLine("Enter {0} for {1}", i, stockObject.StockName);
                Console.WriteLine("{0} shares available", stockObject.NumberOfShare);
                i++;
            }
            ////option is index for corresponding share company
            int option = this.IntInput();
            Console.WriteLine("Enter a Number of Shares you want to buy");
            ////share count have how much share you want
            int shareCount = this.IntInput();
            ////jobject is created for checking available shares and share value finding
            JObject jobj = JObject.Parse(stockFile);
            ////assigned here
            int sharesAvailable = (int)jobj["Stock"][option]["NumberOfShare"];
            int shareValue = (int)jobj["Stock"][option]["SharePrice"];
            ////if the share count is equal or less then to available then only it enters
            if (sharesAvailable >= shareCount)
            {
                ////takes the name
                Console.WriteLine("Enter your name");
                string name = Console.ReadLine();
                ////user object is created to add or update the data
                string userFile = File.ReadAllText(@"D:\BridgeLabzBhush\ObjectOrientedPrograms\ObjectOrientedPrograms\StockUsers.json");
                UserList userList = JsonConvert.DeserializeObject<UserList>(userFile);
                ////userIndex is needed to update data at perticular location
                int userIndex = this.UserIndex(name);
                ////if the returned data in -1 means user is not have an account
                if (userIndex  == -1)
                {
                    Console.WriteLine("User Not Available");
                    return;
                }
                ////else now shres available in stock is reduced by share count
                sharesAvailable -= shareCount;
                ////number of shares are updated
                jobj["Stock"][option]["NumberOfShare"] = sharesAvailable;
                string output = JsonConvert.SerializeObject(jobj,Formatting.Indented);
                File.WriteAllText(@"D:\BridgeLabzBhush\ObjectOrientedPrograms\ObjectOrientedPrograms\StockFile.json",output);
                ////jobj1 is created for updating the user file
                JObject jobj1 = JObject.Parse(userFile);
                ////taking company name here for checking if it is already available in list or not
                string companyName = (string)jobj["Stock"][option]["StockName"];
                ////checking the index
                int shareIndex = this.ShareCompanyIndex(name, companyName);
                ////if returned value is -1 means company is new 
                if (shareIndex == -1)
                {
                    this.AddNewShare(name, companyName, shareCount, shareValue, userIndex);
                    return;
                }
                ////it udates the current data with new values
                var value = jobj1["StockUsers"][userIndex]["NumberOfShares"];
                var value1 = value[shareIndex];
                jobj1["StockUsers"][userIndex]["NumberOfShares"][shareIndex] = shareCount + (int)value1;
                ////rewrite it in the file
                string userOutput = JsonConvert.SerializeObject(jobj1, Formatting.Indented);
                File.WriteAllText(@"D:\BridgeLabzBhush\ObjectOrientedPrograms\ObjectOrientedPrograms\StockUsers.json", userOutput);
            }
        }

        public int UserIndex(string name)
        {
            int i = 0;
            string userFile = File.ReadAllText(@"D:\BridgeLabzBhush\ObjectOrientedPrograms\ObjectOrientedPrograms\StockUsers.json");
            UserList stock = JsonConvert.DeserializeObject<UserList>(userFile);
            foreach (UserObject stockObject in stock.StockUsers)
            {
                if (stockObject.Name.Equals(name))
                {
                    Console.WriteLine(i);
                    return i;
                }
                i++;
            }
            return -1;
        }
        public int ShareCompanyIndex(string name, string companyName)
        {
            int companyIndex = 0 ;
            string userFile = File.ReadAllText(@"D:\BridgeLabzBhush\ObjectOrientedPrograms\ObjectOrientedPrograms\StockUsers.json");
            UserList stock = JsonConvert.DeserializeObject<UserList>(userFile);
            foreach (UserObject stockObject in stock.StockUsers)
            {
                if (stockObject.Name.Equals(name))
                {
                    int companyCount = stockObject.NumberOfShares.Count;
                    for (int temp = 0; temp < companyCount; temp++)
                    {
                        if (stockObject.CompanyShares[companyIndex].Equals(companyName))
                        {
                            Console.WriteLine(companyIndex);
                            return companyIndex;
                        }
                        companyIndex++;
                    }
                }
               
            }
            return -1;
        }

        public void AddNewShare(string name, string companyName, int shareCount, int shareValue, int userIndex)
        {
            string userFile = File.ReadAllText(@"D:\BridgeLabzBhush\ObjectOrientedPrograms\ObjectOrientedPrograms\StockUsers.json");
            UserList userList = JsonConvert.DeserializeObject<UserList>(userFile);
            JObject jObject = JObject.Parse(userFile);
            foreach (UserObject userObject in userList.StockUsers)
            {
                if (userObject.Name.Equals(name))
                {
                    userObject.CompanyShares.Add(companyName);
                    userObject.NumberOfShares.Add(shareCount);
                    userObject.ShareValue.Add(shareValue);
                    userList.StockUsers.Add(userObject);
                    userList.StockUsers.RemoveAt(userIndex);
                    break;
                }
            }



            string userOutput = JsonConvert.SerializeObject(userList, Formatting.Indented);
            File.WriteAllText(@"D:\BridgeLabzBhush\ObjectOrientedPrograms\ObjectOrientedPrograms\StockUsers.json", userOutput);
        }
    }
}
