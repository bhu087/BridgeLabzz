////------------------------------------------------------------------------
////<copyright file="BookFacade.cs" company="BridgeLabz">
////author="Bhushan"
////</copyright>
////-------------------------------------------------------------------------
namespace DesignPattern.StructuralDesignPatterns.FacadePattern
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// The Book Facade class
    /// </summary>
    class BookFacade
    {
        /// <summary>
        /// Books the facade pattern.
        /// </summary>
        public static void BookFacadePattern()
        {
            Utility utility = new Utility();
            BookDetails bookDetails = new BookDetails();
            bookDetails.BookAuthors();
            //bookDetails.KavaluAuthor();
            //bookDetails.RunaAuthor();
            //bookDetails.JanaAuthor();
            Console.WriteLine("1 for Kavaludaari\n2 for Runa\n3 for Janapada");
            switch (utility.IntiInput())
            {
                case 1:
                    Console.Clear();
                    bookDetails.KavaluAuthor();
                    break;
                case 2:
                    Console.Clear();
                    bookDetails.RunaAuthor();
                    break;
                case 3:
                    Console.Clear();
                    bookDetails.JanaAuthor();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Wrong selection");
                    BookFacadePattern();
                    break;
            }
        }
    }
}
