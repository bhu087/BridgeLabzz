using System;
using System.Collections.Generic;
using System.Text;

namespace ObjectOrientedPrograms
{
    class DeckOfCardsUsingLinkedList:DeckOfCards
    {
        MyLinkedList<string> SuitList = new MyLinkedList<string>();
        MyLinkedList<string> RankList = new MyLinkedList<string>();
        MyLinkedList<int> SuitCardsList = new MyLinkedList<int>();
        MyLinkedList<int> RankCardsList = new MyLinkedList<int>();
        public void DeckOfCardsLinkedList()
        {
            DeckOfCards extnd = new DeckOfCards();
            Utility deckUtility = new Utility();
            SuitList = deckUtility.suitInitialization(SuitList);
            RankList = deckUtility.rankInitialization(RankList);
            SuitCardsList = deckUtility.MaxCardInitialization(SuitCardsList);
            RankCardsList = deckUtility.MaxSuitInitialization(RankCardsList);

            MyLinkedList<string> user1 = new MyLinkedList<string>();
            MyLinkedList<string> user2 = new MyLinkedList<string>();
            MyLinkedList<string> user3 = new MyLinkedList<string>();
            MyLinkedList<string> user4 = new MyLinkedList<string>();

            for (int i = 0; i < 9; i++)
            {
                user1.Add(Play());
                user2.Add(Play());
                user3.Add(Play());
                user4.Add(Play());
            }
            user1 = Sort(user1);
            user2 = Sort(user2);
            user3 = Sort(user3);
            user4 = Sort(user4);
            Console.WriteLine("...................................................");
            user1.Display();
            Console.WriteLine("...................................................");
            user2.Display();
            Console.WriteLine("...................................................");
            user3.Display();
            Console.WriteLine("...................................................");
            user4.Display();

        }
        public MyLinkedList<string> Sort(MyLinkedList<string> mylinkedList)
        {
            int size = mylinkedList.Size();
            string[] s = new string[size];
            for (int i = 0; i < size; i++)
            {
                s[i] = mylinkedList.Pop();
            }
            for (int i = 0; i < size; i++)
            {
                for (int j = i + 1; j < size; j++)
                {
                    char strI = s[i].ToCharArray()[0];
                    char strJ = s[j].ToCharArray()[0];
                    if (strI == '1')
                    {
                        strI = '9';
                    }
                    if (strJ == '1')
                    {
                        strJ = '9';
                    }
                    if (strI.CompareTo(strJ) >= 0)
                    {
                        string tempstring = s[i];
                        s[i] = s[j];
                        s[j] = tempstring;
                    }
                }
            }
            for (int i = 0; i < size; i++)
            {
                mylinkedList.Add(s[i]);
            }
            return mylinkedList;
        }
    }
}
