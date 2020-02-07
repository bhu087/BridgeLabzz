////------------------------------------------------------------------------
////<copyright file="BookDetails.cs" company="BridgeLabz">
////author="Bhushan"
////</copyright>
////-------------------------------------------------------------------------
namespace DesignPattern.StructuralDesignPatterns.FacadePattern
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Book Details
    /// </summary>
    public class BookDetails
    {
        /// <summary>
        /// The book1
        /// </summary>
        private IBook book1;

        /// <summary>
        /// The book2
        /// </summary>
        private IBook book2;

        /// <summary>
        /// The book3
        /// </summary>
        private IBook book3;

        /// <summary>
        /// Books the authors.
        /// </summary>
        public void BookAuthors()
        {
            this.book1 = new Kavaludaari();
            this.book2 = new Runa();
            this.book3 = new Janapada();
        }

        /// <summary>
        /// Kavalu author.
        /// </summary>
        public void KavaluAuthor()
        {
            this.book1.Author();
        }

        /// <summary>
        /// Runa author.
        /// </summary>
        public void RunaAuthor()
        {
            this.book2.Author();
        }

        /// <summary>
        /// Janapada book author.
        /// </summary>
        public void JanaAuthor()
        {
            this.book3.Author();
        }
    }
}
