////...................................
////<copyright file="AddressBook.cs" company="BridgeLabz">
//// author="Bhushan"
////</copyright>
////...................................
namespace AddressBook
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// This is address book
    /// </summary>
    public class AddressBook
    {
        /// <summary>
        /// Addresses book method.
        /// </summary>
        public static void AddressBookMethod()
        {
            Utility addressUtility = new Utility();
            Console.WriteLine("Welcome to Address Book");
            Console.WriteLine("1 for Add a person\n2 for Edit a person\n3 for Delete a person");
            Console.WriteLine("4 for Sort by Names\n5 for sort by ZIP\n6 for print entries");
            int option = addressUtility.IntInput();
            switch (option)
            {
                case 1:
                    addressUtility.AddAPerson();
                    break;
                case 2:
                    addressUtility.EditPerson();
                    break;
                case 3:
                    addressUtility.DeleteContact();
                    break;
                case 4:
                    addressUtility.SortByName();
                    break;
                case 5:
                    addressUtility.SortByNumber();
                    break;
                case 6:
                    addressUtility.PrintEntries();
                    break;
            }
        }
    }
}
