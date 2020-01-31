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
Name:       Console.Write("Enter a name");
            string name = Console.ReadLine();
            if (this.DuplicateName(name))
            {
                Console.WriteLine("Name already exists");
                goto Name;
            }
Number:     Console.Write("Enter a Number");
            long number = this.LongInput();
            if (this.DuplicateNumber(number))
            {
                Console.WriteLine("Number already exists");
                goto Number;
            }
            Console.Write("Company :");
            string company = Console.ReadLine();
            this.CreateContact(name,number,company);
        }

        public void CreateContact(string name, long number, string company)
        {
            AddressObject addressObject = new AddressObject
            {
                Name = name,
                MobileNumber = number,
                Company = company
            };
            AddObjList.Add(addressObject);
            string output = JsonConvert.SerializeObject(AddList, Formatting.Indented);
            File.WriteAllText(@"D:\BridgeLabzBhush\ObjectOrientedPrograms\AddressBook\AddressBook\AddressBook\AddressFile.json", output);
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
            int i = 0;
            Console.WriteLine("edit");
            foreach (AddressObject contact in AddObjList)
            {
                Console.WriteLine("{0} for edit {1}", i, contact.Name);
                i++;
            }

            i = this.IntInput();
            Console.WriteLine("0 for edit name\n1 for Edit Mobile Number\n2 for edit Company");
            int option = this.IntInput();
            switch (option)
            {
                case 0:
EditName:           Console.WriteLine("Enter New Name : ");
                    string newName = Console.ReadLine();
                    if (this.DuplicateName(newName))
                    {
                        Console.WriteLine("Name already exist");
                        goto EditName;
                    }
                    dyn["AddressDetails"][i]["Name"] = newName;
                    break;
                case 1:
EditNumber:         Console.WriteLine("Enter New Number");
                    long newNumber = this.LongInput();
                    if (this.DuplicateNumber(newNumber))
                    {
                        Console.WriteLine("Number already exist");
                        goto EditNumber;
                    }
                    dyn["AddressDetails"][i]["MobileNumber"] = newNumber;
                    break;
                case 2:
                    Console.WriteLine("Enter New Company");
                    string newCompany = Console.ReadLine();
                    dyn["AddressDetails"][i]["Name"] = newCompany;
                    break;
                default:
                    break;
            }
            string output = JsonConvert.SerializeObject(dyn,Formatting.Indented);
            File.WriteAllText(@"D:\BridgeLabzBhush\ObjectOrientedPrograms\AddressBook\AddressBook\AddressBook\AddressFile.json", output);
        }

        public void DeleteContact()
        {
            int i = 0;
            foreach (AddressObject contact in AddObjList)
            {
                Console.WriteLine("{0} for delete {1}", i, contact.Name);
                i++;
            }
            i = this.IntInput();
            AddObjList.RemoveAt(i);
            string output = JsonConvert.SerializeObject(AddList,Formatting.Indented);
            File.WriteAllText(@"D:\BridgeLabzBhush\ObjectOrientedPrograms\AddressBook\AddressBook\AddressBook\AddressFile.json",output);
        }
    }
}
