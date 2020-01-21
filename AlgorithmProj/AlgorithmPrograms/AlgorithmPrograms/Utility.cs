﻿namespace AlgorithmPrograms
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.RegularExpressions;

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

		//Bubble sort Integer 
		public int[] IntegerBubbleSort(int[] IntArray)
		{
			int Count = IntArray.Length - 1;
			int TempVariable;
			for (int i = 0; i < 5; i++)
			{
				for (int j = 0; j < Count; j++)
				{
					if (IntArray[j].CompareTo(IntArray[j + 1]) > 0)
					{
						TempVariable = IntArray[j];
						IntArray[j] = IntArray[j + 1];
						IntArray[j + 1] = TempVariable;
					}
				}
				Count--;
			}
			return IntArray;
		}

		//Anagram String finder
		public int AnagramStringFinder(string String1, string String2)
		{
			char[] CharString = String1.ToCharArray();
			Array.Sort(CharString);
			String1 = new string(CharString);
			CharString = String2.ToCharArray();
			Array.Sort(CharString);
			String2 = new string(CharString);
			return String1.CompareTo(String2);
		}
		//Given integer is anagram
		public void AnagramFinder(int[] IntegerArray)
		{
			string IntegerString = string.Empty;
			string IntegerString1 = string.Empty;
			for (int i = 0; i < IntegerArray.Length; i++)
			{
				int TempValue = IntegerArray[i];
				IntegerString = Convert.ToString(IntegerArray[i]);
				char[] CharString = IntegerString.ToCharArray();
				Array.Sort(CharString);
				IntegerString = new string(CharString);
				for (int j = i + 1; j < IntegerArray.Length; j++)
				{
					IntegerString1 = Convert.ToString(IntegerArray[j]);
					CharString = IntegerString1.ToCharArray();
					Array.Sort(CharString);
					string ImegerString2 = new string(CharString);
					if (IntegerString.CompareTo(ImegerString2) == 0)
					{
						Console.WriteLine("{0} {1} are anagram", TempValue, IntegerString1);
					}
				}
			}
		}

		//prime Numbers utility
		public int[] PrimeNumbersUtility(int PrimeNumberRange)
		{
			//
			int MiddleNumber, Flag, i;
			//initialize the array size here
			int PrimeNumbersCountount = primeNumberCounter(PrimeNumberRange);
			int[] PrimeArray = new int[PrimeNumbersCountount];
			Console.WriteLine("Total Prime Numbers Countis {0} ", PrimeNumbersCountount);
			int ArrayIndex = 0;
			//it will satrts checking value from 2 till given range
			for (int k = 2; k < PrimeNumberRange; k++)
			{
				//to find the maximun middle value
				MiddleNumber = k / 2;
				//flag is for denoting given value is prime or not
				Flag = 1;
				//it will starts deviding a value from 2 to middle value
				//if the the value divisible by any value between (2 to Middle value) then exit the loop
				//else make flag as 1 and stores in to prime Array
				for (i = 2; i <= MiddleNumber; i++)
				{
					if (k % i == 0)
					{
						Flag = 0;
						break;
					}
					else
					{
						Flag = 1;
					}
				}
				if (Flag == 1)
				{
					PrimeArray[ArrayIndex] = k;
					ArrayIndex++;
				}
			}
			//returns the array
			return PrimeArray;
		}

		//count prime number count 
		public int primeNumberCounter(int RangeForCounting)
		{
			int b;
			int Flag;
			int i = 0, Count = 0;
			//This is for Counting Number of prime numbers between the range
			for (int k = 2; k < RangeForCounting; k++)
			{
				b = k / 2;
				Flag = 1;
				for (i = 2; i <= b; i++)
				{
					if (k % i == 0)
					{
						Flag = 0;
						break;
					}
					else
					{
						Flag = 1;
					}
				}
				if (Flag == 1)
				{
					Count++;
				}
			}
			//returns Total count
			return Count;
		}

		//This is the regex program
		public string RegExUtility()
		{
			//Standard String
			string StandardMessage = "Hello << name >>, We have your full name as <<full name>> in our " +
				"system.your contact number is 91-xxxxxxxxxx.Please, let us know in case of any clarification " +
				"Thank you BridgeLabz 01/01/2016.";
			//RegEx formats for MobileNumber
			Regex MobileNumberFormat = new Regex("^[1-9]{1}[0-9]{9}$");
			//regex format for Name
			Regex NameFormat = new Regex("^[a-zA-Z]{3,20}$");
			Console.WriteLine("Enter Your First Name");
			string FirstName = Console.ReadLine();
			//if name format not matches regex then it returns the error else enter to next step
			if (NameFormat.IsMatch(FirstName))
			{
				Console.WriteLine("Enter Your Last Name");
				string LastName = Console.ReadLine();
				//if name format not matches regex then it returns the error else enter to next step
				if (NameFormat.IsMatch(LastName))
				{
					Console.WriteLine("Enter Your Mobile Number");
					string PhoneNumber = Console.ReadLine();
					//if Mobile Number format not matches regex then it returns the error else enter to next step
					//and returns String to display
					if (MobileNumberFormat.IsMatch(PhoneNumber))
					{
						StandardMessage = StandardMessage.Replace("<< name >>", FirstName);
						StandardMessage = StandardMessage.Replace("<<full name>>", FirstName+" "+LastName);
						StandardMessage = StandardMessage.Replace("xxxxxxxxxx", PhoneNumber);
						StandardMessage = StandardMessage.Replace("01/01/2016",DateTime.Now.ToString(@"dd\/MM\/yyyy"));
						return StandardMessage;
					}
					else
						return "Your Mobile Number is Not in the Number Format";
				}
				else
					return "Your Last Name is Not in the Charector Format";
			}
			else
			{
				return "Your First Name is Not in the Charector Format";
			}
		}
		//Find Numbers in N Questions Utility function
		public void searchNum(int MaxNumber)
		{
			//Enter the maximum value from 0 to maximum value
			int High = MaxNumber;
			int Low = 0;
			int Middle = (High + Low) / 2;
			Console.WriteLine("press 0 for " + Middle + " and below  \npress 1 for " + (Middle + 1) + " and above");
			int i = int.Parse(Console.ReadLine());
			while (Middle != Low)
			{
				//if the value from low to middle this block will execute
				if (i == 0)
				{
					High = Middle;
					Middle = (Low + High) / 2;
					Console.WriteLine("press 0 for " + Middle + " and below  \npress 1 for " + (Middle + 1) + " and above");
					i = int.Parse(Console.ReadLine());
					Console.WriteLine(i);
				}
				//if the value from Middle to high this block will execute
				if (i == 1)
				{
					Low = Middle + 1;
					Middle = (Low + High) / 2;
					Console.WriteLine("press 0 for " + Middle + " and below \npress 1 for " + (Middle + 1) + " and above");
					i = int.Parse(Console.ReadLine());
					Console.WriteLine(i);
				}
			}
			if (i == 0)
			{    
				//one more comparison is here
				Console.WriteLine("Your Number is " + Low);
			}
			if (i == 1)
			{   
				//one more comparison is here
				Console.WriteLine("Your Number is " + High);
			}
		}
	}
}

