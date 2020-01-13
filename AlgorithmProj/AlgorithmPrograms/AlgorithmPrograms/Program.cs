using System;

namespace AlgorithmPrograms
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your option\n1 for Binary word search\n2 for Strimg Insertion sort" +
                "");
            try
            {
                int Option = int.Parse(Console.ReadLine());
                switch (Option)
                {
                    case 1:
                        BinaryWordSearchProgram.BinaryWordSearch();
                        break;
                    case 2:
                        InsertionSortProgram.InsertionSort();
                        break;
                    default:
                        Console.WriteLine("You have entered Wrong Option");
                        break;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("You are entered wrong input\nTry again...");
            }
        }
    }
}
