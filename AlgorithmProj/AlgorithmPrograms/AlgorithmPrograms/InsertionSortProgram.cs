﻿// <auto-generated/>
namespace AlgorithmPrograms
{
	using System;
	using System.Collections.Generic;
	using System.Text;

	/// <summary>
	/// this is string insertion sort program
	/// </summary>
	class InsertionSortProgram
	{
		/// <summary>
		/// 
		/// </summary>
		public static void InsertionSort()
		{
			Utility InsertionUtility = new Utility();
			string[] InputStringArray = { "ZZZ", "VVV", "III", "BBB", "CCC", "AAA" };
			Console.WriteLine("Your string array is [{0}]", string.Join(", ", InputStringArray));
			InputStringArray = InsertionUtility.InsertionSortUtility(InputStringArray);
			Console.WriteLine("Your sorted Array");
			for (int i = 0; i < InputStringArray.Length; i++)
			{
				Console.Write(InputStringArray[i] + ", ");
			}
		}
	}
}
