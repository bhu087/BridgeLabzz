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
            Console.WriteLine("...................................................");
            user1.Display();
            Console.WriteLine("...................................................");
            user2.Display();
            Console.WriteLine("...................................................");
            user3.Display();
            Console.WriteLine("...................................................");
            user4.Display();

        }
    }
}
