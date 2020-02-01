////...................................
////<copyright file="Utility.cs" company="BridgeLabz">
//// author="Bhushan"
////</copyright>
////...................................
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
    public class Utility
    {
        /// <summary>
        /// The add book is the file
        /// </summary>
        public static string AddBook = File.ReadAllText(@"D:\BridgeLabzBhush\ObjectOrientedPrograms\AddressBook\AddressBook\AddressBook\AddressFile.json");

        /// <summary>
        /// The added list
        /// </summary>
        public static AddressList AddList = JsonConvert.DeserializeObject<AddressList>(AddBook);

        /// <summary>
        /// The add object list
        /// </summary>
        public static List<AddressObject> AddObjList = AddList.AddressDetails;

        /// <summary>
        /// Integer input.
        /// </summary>
        /// <returns>return Integer</returns>
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
        /// Longs the input.
        /// </summary>
        /// <returns>returns long value</returns>
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
            this.CreateContact(name, number, company);
        }

        /// <summary>
        /// Creates the contact.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="number">The number.</param>
        /// <param name="company">The company.</param>
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

        /// <summary>
        /// Duplicates the name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>returns true or false</returns>
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

        /// <summary>
        /// Duplicates the number.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>returns boolean value</returns>
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

        /// <summary>
        /// Edits the person.
        /// </summary>
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

            try
            {
                i = this.IntInput();
                Console.WriteLine("0 for edit name\n1 for Edit Mobile Number\n2 for edit Company");
                int option = this.IntInput();
                switch (option)
                {
                    case 0:
                    EditName: Console.WriteLine("Enter New Name : ");
                        string newName = Console.ReadLine();
                        if (this.DuplicateName(newName))
                        {
                            Console.WriteLine("Name already exist");
                            goto EditName;
                        }

                        dyn["AddressDetails"][i]["Name"] = newName;
                        break;
                    case 1:
                    EditNumber: Console.WriteLine("Enter New Number");
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

                string output = JsonConvert.SerializeObject(dyn, Formatting.Indented);
                File.WriteAllText(@"D:\BridgeLabzBhush\ObjectOrientedPrograms\AddressBook\AddressBook\AddressBook\AddressFile.json", output);
                Console.WriteLine("Update successful");
            }
            catch (Exception)
            {
                Console.WriteLine("You are entered Wrong input");
            }
        }

        /// <summary>
        /// Deletes the contact.
        /// </summary>
        public void DeleteContact()
        {
            int i = 0;
            foreach (AddressObject contact in AddObjList)
            {
                Console.WriteLine("{0} for delete {1}", i, contact.Name);
                i++;
            }

            try
            {
                i = this.IntInput();
                AddObjList.RemoveAt(i);
                string output = JsonConvert.SerializeObject(AddList, Formatting.Indented);
                File.WriteAllText(@"D:\BridgeLabzBhush\ObjectOrientedPrograms\AddressBook\AddressBook\AddressBook\AddressFile.json", output);
                Console.WriteLine("Deleted successfully");
            }
            catch (Exception)
            {
                Console.WriteLine("You selected wrong entry");
            }
        }

        /// <summary>
        /// Sorts the name of the by.
        /// </summary>
        public void SortByName()
        {
            List<string> myList = new List<string>();
            foreach (AddressObject var in AddObjList)
            {
                string tempString = var.Name + " " + var.MobileNumber + " " + var.Company;
                myList.Add(tempString);
            }

            myList.Sort();
            foreach (string str in myList)
            {
                Console.WriteLine(str);
            }
        }

        /// <summary>
        /// Sorts the by number.
        /// </summary>
        public void SortByNumber()
        {
            List<string> myList = new List<string>();
            foreach (AddressObject var in AddObjList)
            {
                string tempString = var.MobileNumber + " " + var.Name + " " + var.Company;
                myList.Add(tempString);
            }

            myList.Sort();
            foreach (string str in myList)
            {
                Console.WriteLine(str);
            }
        }
    }
}
