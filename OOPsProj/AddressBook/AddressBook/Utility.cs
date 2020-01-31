namespace AddressBook
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

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
        public long LongInput()
        {
            try
            {
                long input = long.Parse(Console.ReadLine());
                return input;
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid entry\nTry again...");
                this.LongInput();
                return 0;
            }
        }

        /// <summary>
        /// Adds a person.
        /// </summary>
        public void AddAPerson()
        {
            Console.Write("First Name :");
            string name = Console.ReadLine();
            if (this.DuplicateName(name))
            {
                Console.WriteLine("Contact for this name already exists\ntry anethor");
                this.AddAPerson();
            }
            long number = this.Number();
            Console.WriteLine("Compony :");
            string company = Console.ReadLine();
            AddressObject addressObject = new AddressObject
            {
                Name = name,
                MobileNumber = number,
                Company = company
            };
            AddObjList.Add(addressObject);
            string output = JsonConvert.SerializeObject(AddList,Formatting.Indented);
            File.WriteAllText(@"D:\BridgeLabzBhush\ObjectOrientedPrograms\AddressBook\AddressBook\AddressBook\AddressFile.json",output);
        }

        public long Number()
        {
            Console.Write("Mobile Number :");
            long number = this.LongInput();
            if (this.DuplicateNumber(number))
            {
                Console.WriteLine("Number Already exists");
                this.Number();
            }
            return number;
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

        public bool DuplicateName(string name)
        {
            foreach (AddressObject contacts in AddObjList)
            {
                if (contacts.Name.Equals(name))
                {
                    return true;
                }
            }
            return false;
        }
        public bool DuplicateNumber(long number)
        {
            foreach (AddressObject contacts in AddObjList)
            {
                if (contacts.MobileNumber == number)
                {
                    return true;
                }
            }
            return false;
        }

        public void EditPerson()
        {
            dynamic dyn = JObject.Parse(AddBook);
            
        }
    }
}
