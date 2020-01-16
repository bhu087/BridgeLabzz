using System;
using System.Collections.Generic;
using System.Text;
using DataStructurePrograms;

namespace DataStructurePrograms
{
    class BankingCashCounterProgram
    {
        public static void ServiceSelection()
        {
            BankServiceControlProgram ServiceSelectionUTL = new BankServiceControlProgram();
First:      Console.WriteLine("Enter your Option\n1: for Entry\n2: for Give a service to Front user Withdrawn/Deposit\n3: for Q is Empty" +
                "\n4: Q Size\n5: for Exit");
Home:       try
            {
                int Selection = int.Parse(Console.ReadLine());
                if (Selection < 5) 
                {
                    ServiceSelectionUTL.BankQueueService(Selection);
                    goto First;
                }
                else
                {
                    Console.WriteLine("Wrong Option");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid Option");
                goto Home;
            }
        }
    }
}
