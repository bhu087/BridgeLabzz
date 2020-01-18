using System;
using System.Collections.Generic;
using System.Text;

namespace OrderedLinkedList
{
    class Utility
    {
        public void PrimeNumberUtility(int Range)
        {
            int Dimensions = Range / 100;
            IntegerLinkedListProgram[] OrderedListUTL = new IntegerLinkedListProgram[Dimensions];
            int j;
            int Flag = 0;

            for (int i = 0; i < Dimensions; i++)
            {
                OrderedListUTL[i] = new IntegerLinkedListProgram();
            }
            IntegerLinkedListProgram FullPrimeList = new IntegerLinkedListProgram();
            IntegerLinkedListProgram AnagramsList = new IntegerLinkedListProgram();
            for (int i = 3; i < Range; i++)
            {
                Flag = 0;
                for(j = 2; j <= i / 2; j++)
                {
                    if ( i%j == 0)
                    {
                        Flag = 0;
                        break;
                    }
                    else
                    {
                        Flag = 1;
                    }
                }
                if(Flag == 1)
                {
                    FullPrimeList.add(i);
                    if (i<=100)
                    {
                        OrderedListUTL[0].add(i);
                    }
                    if (i <= 200 && i>100)
                    {
                        OrderedListUTL[1].add(i);
                    }
                    if (i <= 300 && i > 200)
                    {
                        OrderedListUTL[2].add(i);
                    }
                    if (i <= 400 && i > 300)
                    {
                        OrderedListUTL[3].add(i);
                    }
                    if (i <= 500 && i > 400)
                    {
                        OrderedListUTL[4].add(i);
                    }
                    if (i <= 600 && i > 500)
                    {
                        OrderedListUTL[5].add(i);
                    }
                    if (i <= 700 && i > 600)
                    {
                        OrderedListUTL[6].add(i);
                    }
                    if (i <= 800 && i > 700)
                    {
                        OrderedListUTL[7].add(i);
                    }
                    if (i <= 900 && i > 800)
                    {
                        OrderedListUTL[8].add(i);
                    }
                    if (i > 900)
                    {
                        OrderedListUTL[9].add(i);
                    }
                }
            }
            for (int i = 0; i < Dimensions; i++)
            {
                Console.Write("{0} to {1} :", i * 100, (i + 1) * 100);
                OrderedListUTL[i].DisplayLine();
                Console.WriteLine();
            }
            int size = FullPrimeList.Size();
            for (int i=0; i < size; i++)
            {
                string str = Convert.ToString(FullPrimeList.ValueAt(i));
                char[] CharArray1 = str.ToCharArray();
                Array.Sort(CharArray1);
                str = new string(CharArray1);
                for(int k = i + 1; k < size; k++)
                {
                    string str2 = Convert.ToString(FullPrimeList.ValueAt(k));
                    char[] CharArray2 = str2.ToCharArray();
                    Array.Sort(CharArray2);
                    str2 = new string(CharArray2);
                    if (str.Equals(str2))
                    {
                        AnagramsList.add(FullPrimeList.ValueAt(i));
                        FullPrimeList.remove(FullPrimeList.ValueAt(i));
                        FullPrimeList.remove(FullPrimeList.ValueAt(k));
                        size = FullPrimeList.Size();
                    }
                }
            }
            ///////////////////////////////////////////////Console.WriteLine("Entered Here");
            Console.WriteLine("....................................................");
            AnagramsList.Display();
            Console.WriteLine("....................................................");
            FullPrimeList.Display();
        }
    }
}
