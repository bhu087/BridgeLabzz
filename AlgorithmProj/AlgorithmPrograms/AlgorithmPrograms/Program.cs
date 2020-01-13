using System;

namespace AlgorithmPrograms
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your option\n1 for Binary word search");
            try
            {
                int Option = int.Parse(Console.ReadLine());
                switch (Option)
                {
                    case 1:
                        BinaryWordSearchProgram.BinaryWordSearch();
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
