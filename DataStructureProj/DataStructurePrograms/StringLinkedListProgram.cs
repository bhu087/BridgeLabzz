﻿//<auto-generated/>
namespace DataStructurePrograms
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.IO;

    class StringLinkedListProgram
    {
        public static void StringLinkedList()
        {
            MyLinkedList myLinkedListUTL = new MyLinkedList();
            //these are the seperators use in paragraph and we need to remove these in list entry
            string[] Separators = new string[] { " ", ",", ".", "!", "\'", " ", "\'s" };
            //thias is the filepath and need to import using System.IO;
            string FilePath = @"D:\BridgeLabzBhush\AlgorithmPrograms\AlgorithmPrograms\bin\Debug\netcoreapp3.1\SampleString.txt";
            //String array is used to store the all the data present in file this is in line by line manner
            string[] StringArray = File.ReadAllLines(FilePath);
            //Console.WriteLine();
            //This is the temporary string is used to append all the strings in one string
            string TempString = string.Empty;
            foreach (Object Str in StringArray)
            {
                TempString += Str;
            }
            //in this section splitted at space and removes all the seperatos and added to linked list
            foreach (string EachWord in TempString.Split(Separators, StringSplitOptions.RemoveEmptyEntries))
            {
                myLinkedListUTL.add(EachWord);
            }
            myLinkedListUTL.Append("Great");
            myLinkedListUTL.Append("Bengaluru");
            myLinkedListUTL.remove("the");
            myLinkedListUTL.add(10);
            myLinkedListUTL.add(120);
            myLinkedListUTL.Display();
            int size = myLinkedListUTL.size();
            TempString = string.Empty;
            string[] StringArrayTemp = new string[myLinkedListUTL.size()];
            //all the linked list values take to string array of string array of temp
            for (int i = 0; i < size ; i++)
            {
                StringArrayTemp[i] = (string)myLinkedListUTL.ValueAt(i)+" ";
            }
            //using file Write all lines to rewrite modified data to same file
            File.WriteAllLines(FilePath, StringArrayTemp);
        }
    }
}
