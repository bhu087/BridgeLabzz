using System;
using System.Collections.Generic;
using System.Text;

namespace ObjectOrientedPrograms
{
    class DeckOfCardsUsingLinkedList
    {
        MyLinkedList<string> SuitList = new MyLinkedList<string>();
        MyLinkedList<string> RankList = new MyLinkedList<string>();
        MyLinkedList<int> SuitCardsList = new MyLinkedList<int>();
        MyLinkedList<int> RankCardsList = new MyLinkedList<int>();
        public void DeckOfCardsLinkedList()
        {
            Utility deckUtility = new Utility();
            SuitList = deckUtility.suitInitialization(SuitList);
            RankList = deckUtility.rankInitialization(RankList);
            SuitCardsList = deckUtility.MaxCardInitialization(SuitCardsList);
            RankCardsList = deckUtility.MaxSuitInitialization(RankCardsList);
        }
    }
}
