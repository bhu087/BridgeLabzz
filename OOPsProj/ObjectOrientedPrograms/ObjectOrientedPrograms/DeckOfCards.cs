////...............................................
////<copyright file="DeckOfCards.cs" company="BridgeLabz">
////author="Bhushan"
////</copyright>
////...............................................
namespace ObjectOrientedPrograms
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// the Deck Of Cards class 
    /// </summary>
    public class DeckOfCards
    {
        ////Write a Program DeckOfCards.java, to initialize deck of cards having suit 
        ////("Clubs", "Diamonds", "Hearts", "Spades") & 
        ////Rank (). 
        ////Shuffle the cards using Random method and then distribute 9 Cards to 4 Players and Print the Cards the 
        ////received by the 4 Players using 2D Array…  
        
        /// <summary>
        /// The suit
        /// </summary>
        public static string[] Suit = { "Clubs", "Diamonds", "Hearts", "Spades" };

        /// <summary>
        /// The rank
        /// </summary>
        public static string[] Rank = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };

        /// <summary>
        /// The rank cards
        /// </summary>
        public static int[] RankCards = { 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4 };

        /// <summary>
        /// The suit cards
        /// </summary>
        public static int[] SuitCards = { 13, 13, 13, 13 };

        /// <summary>
        /// Deck of cars method.
        /// </summary>
        public static void Deck()
        {
            string user1 = string.Empty;
            string user2 = string.Empty;
            string user3 = string.Empty;
            string user4 = string.Empty;
            for (int i = 0; i < 9; i++)
            {
                user1 += Play();
                user2 += Play();
                user3 += Play();
                user4 += Play();
            }
            
            Console.WriteLine("User 1 : " + user1);
            Console.WriteLine(".........................................................................................");
            Console.WriteLine("User 2 : " + user2);
            Console.WriteLine(".........................................................................................");
            Console.WriteLine("User 3 : " + user3);
            Console.WriteLine(".........................................................................................");
            Console.WriteLine("User 4 : " + user4);  
        }

        /// <summary>
        /// Plays this instance.
        /// </summary>
        /// <returns>returns string</returns>
        public static string Play()
        {
            Random random = new Random();
            int index;
            int suitIndex;
            string user = string.Empty;
            Here: suitIndex = random.Next(4);
                index = random.Next(13);
                if (RankCards[index] > 0 && SuitCards[suitIndex] > 0)
                {
                    RankCards[index] -= 1;
                    SuitCards[suitIndex] -= 1;
                    user = Suit[suitIndex] + " of " + Rank[index] + ", ";
                }
                else
                {
                goto Here;
                }

            return user;
        }
    }
}
