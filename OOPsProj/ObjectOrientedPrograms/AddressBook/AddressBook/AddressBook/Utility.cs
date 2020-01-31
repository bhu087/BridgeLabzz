namespace AddressBook
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using Newtonsoft.Json;

    /// <summary>
    /// This is utility class for Address book
    /// </summary>
    class Utility
    {
        public static string AddBook = File.ReadAllText(@"D:\BridgeLabzBhush\ObjectOrientedPrograms\AddressBook\AddressBook\AddressBook\AddressFile.json");
        public static AddressList AddList = JsonConvert.DeserializeObject<AddressList>(AddBook);
        public static List<AddressObject> AddObjList = AddList.AddressDetails;

        /// <summary>
        /// Integer input.
        /// </summary>
        /// <returns></returns>
        public int IntInput()
        {
            try
            {
                int input = int.Parse(Console.ReadLine());
                return input;
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid entry\nTry again...");
                this.IntInput();
                return 0;
            }
        }

        /// <summary>
        /// Adds a person.
        /// </summary>
        public void AddAPerson()
        {

        }

        /// <summary>
        /// Prints the entries.
        /// </summary>
        public void PrintEntries()
        {
            foreach (AddressObject contacts in AddObjList)
            {
                Console.WriteLine("NAME : {0} | Mobile Number : {1} | Company : {2}", contacts.Name, contacts.MobileNumber, contacts.Company);
            }
        }
    }
}
