﻿// <auto-generated/>
namespace AlgorithmPrograms
{
	using System;
	using System.Collections.Generic;
	using System.Text;

	/// <summary>
	/// This is the Utility Function for Algorithm programs
	/// </summary>
	class Utility
    {
		//Binary word search utility
		public bool BinaryWordSearching(string SearchString)
		{
			string[] SampleString = { "BBB", "DDD", "CCC", "XXX", "SSS" };
			//here array available at sorted order
			Array.Sort(SampleString);
			int LowIndex = 0;
			int HighIndex = SampleString.Length - 1;
			int MiddleIndex = LowIndex + (HighIndex - LowIndex) / 2;
			//it will checks till low <= High and hi != 0 lo != length of array
			while (LowIndex <= HighIndex && !(HighIndex == 0 || LowIndex == SampleString.Length))
			{
				//if middle index string is equal to given string then return true
				if (SampleString[MiddleIndex].CompareTo(SearchString) == 0)
				{
					return true;
				}
				//else middle string and given string comparision value is greater then 0 it changes the high and middle 
				//Values
				if (SampleString[MiddleIndex].CompareTo(SearchString) > 0)
				{
					HighIndex = MiddleIndex;
					MiddleIndex = HighIndex / 2;
				}
				//if middle and given string comparision values are less then 0 then changes low and middle index values
				if (SampleString[MiddleIndex].CompareTo(SearchString) < 0)
				{
					LowIndex = MiddleIndex + 1;
					MiddleIndex = (LowIndex + (HighIndex - LowIndex) / 2 );
				}
			}
			return false;
		}

		//Insertion sort utility
		public string[] InsertionSortUtility(string[] StringArray)
		{
			string TempString;
			int Count = StringArray.Length;
			//insertion sorting in this block
			for (int i = 0; i < Count; i++)
			{
				for (int j = i + 1; j < Count; j++)
				{
					if (StringArray[i].CompareTo(StringArray[j]) > 0)
					{
						TempString = StringArray[j];
						StringArray[j] = StringArray[i];
						StringArray[i] = TempString;
					}
				}
			}
			//Return sorted array
			return StringArray;
		}
	}
}
