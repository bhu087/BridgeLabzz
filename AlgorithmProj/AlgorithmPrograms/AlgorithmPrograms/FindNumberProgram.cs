using System;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmPrograms
{
    class FindNumberProgram
    {
		public static void FindNumber()
		{
			try
			{
				Utility FindNumberUTL = new Utility();
				Console.Write("Enter a number between 0: ");
				FindNumberUTL.searchNum(int.Parse(Console.ReadLine()));
			}
			catch (Exception)
			{
				Console.WriteLine("Your Input is Wrong\nTry again...");
			}
		}
		
	}
}
