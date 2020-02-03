////.....................................
////<copyright file="DeckOfCardsUsingLinkedList.cs" company="BridgeLabz">
////author="Bhushan"
////</copyright>
////.....................................
namespace ObjectOrientedPrograms
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// this is deck of cards using linked list
    /// </summary>
    /// <seealso cref="ObjectOrientedPrograms.DeckOfCards" />
    public class DeckOfCardsUsingLinkedList : DeckOfCards
    {
        /// <summary>
        /// Deck of cards linked list.
        /// </summary>
        public void DeckOfCardsLinkedList()
        {
            MyQueue<string> myQueue = new MyQueue<string>();
            Utility deckUtility = new Utility();
            ////4 users Linked List
            MyLinkedList<string> user1 = new MyLinkedList<string>();
            MyLinkedList<string> user2 = new MyLinkedList<string>();
            MyLinkedList<string> user3 = new MyLinkedList<string>();
            MyLinkedList<string> user4 = new MyLinkedList<string>();
            ////9 cards for each
            for (int i = 0; i < 9; i++)
            {
                ////Play method is in Deck of cards class and extended it
                user1.Add(DeckOfCards.Play());
                user2.Add(DeckOfCards.Play());
                user3.Add(DeckOfCards.Play());
                user4.Add(DeckOfCards.Play());
            }
            ////sort the user cards by rank
            user1 = deckUtility.Sort(user1);
            user2 = deckUtility.Sort(user2);
            user3 = deckUtility.Sort(user3);
            user4 = deckUtility.Sort(user4);
            ////Add to queue
            myQueue = deckUtility.AddToQueue(user1, "User One", myQueue);
            myQueue = deckUtility.AddToQueue(user2, "User Two", myQueue);
            myQueue = deckUtility.AddToQueue(user3, "User Three", myQueue);
            myQueue = deckUtility.AddToQueue(user4, "User Four", myQueue);
            Console.WriteLine("............+..........+.........+................+............");
            ////4 users with 9 cards and one for user Representation 
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.WriteLine(myQueue.RemoveFromQueue());
                }

                Console.WriteLine("............+..........+.........+................+............");
            }
        }
    }
}
