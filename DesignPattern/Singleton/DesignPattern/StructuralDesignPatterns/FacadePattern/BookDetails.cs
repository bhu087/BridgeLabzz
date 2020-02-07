using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.StructuralDesignPatterns.FacadePattern
{
    class BookDetails
    {
        private IBook book1;
        private IBook book2;
        private IBook book3;
        public void BookAuthors()
        {
            book1 = new Kavaludaari();
            book2 = new Runa();
            book3 = new Janapada();
        }
        public void KavaluAuthor()
        {
            book1.Author();
        }
        public void RunaAuthor()
        {
            book2.Author();
        }
        public void JanaAuthor()
        {
            book3.Author();
        }
    }
}
