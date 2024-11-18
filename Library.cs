using Personal_Library.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Personal_Library
{
    internal class LibraryManagement
    {
        private List<Books> _bookList;

        internal LibraryManagement()
        {
            _bookList = new List<Books>();
        }

        public void AddBook()
        {
            Books newBook = new Books();

            Console.WriteLine("Please enter your title book:");
            newBook.Title = Console.ReadLine();

            Console.WriteLine("Please enter author of the book:");
            newBook.Author = Console.ReadLine();

            newBook.Genre = ValidationCenter.GetValidGenre();

            _bookList.Add(newBook);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Add book is Done!");
            Thread.Sleep(500);
        }

        public void ListBook()
        {

            Console.WriteLine(new string('=', 55));
            Console.WriteLine("{0,-20} {1,-20} {2,-15}", "Title", "Author", "Genre");
            Console.WriteLine(new string('-', 55));

            foreach (Books book in _bookList)
            {
                Console.WriteLine("{0,-20} {1,-20} {2,-15}", book.Title, book.Author, book.Genre);
            }

            Console.WriteLine(new string('=', 55));

            Console.WriteLine("1. Go to menu\n2. Exit");

            int inputUser = Convert.ToInt16(Console.ReadLine());
            if (inputUser == 2)
            {
                Environment.Exit(0);
            }
        }

        public void SearchBook()
        {
        }

        public void RemoveBook()
        {
        }





    }
}
