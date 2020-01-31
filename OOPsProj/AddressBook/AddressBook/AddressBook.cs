using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBook
{
    class AddressBook
    {
        public static void AddressBookMethod()
        {
            Utility AddressUtility = new Utility();
            Console.WriteLine("Welcome to Address Book");
            Console.WriteLine("1 for Add a person\n2 for Edit a person\n3 for Delete a person");
            Console.WriteLine("4 for Sort by Names\n5 for sort by ZIP\n6 for print entries");
            int option = AddressUtility.IntInput();
            switch (option)
            {
                case 6:
                    AddressUtility.PrintEntries();
                    break;
            }
        }
    }
}
