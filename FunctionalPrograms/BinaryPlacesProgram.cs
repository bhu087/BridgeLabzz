using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionalPrograms
{
    class BinaryPlacesProgram
    {

		public static void BinaryPlaces()
		{
			Utility ToBinaryUTL = new Utility();
			Console.WriteLine("Enter a Decimal Number to find base 2 position");
Start:		try
			{
				int DecimalNumber = int.Parse(Console.ReadLine());
				Console.WriteLine("Binary places representation is");
				Console.Write(ToBinaryUTL.PositionDeciValue(DecimalNumber));
				Console.WriteLine("=" + DecimalNumber);
			}
			catch (Exception)
			{
				Console.WriteLine("Invalid Entry\nTry again...");
				goto Start;
			}
		}
	}
}
