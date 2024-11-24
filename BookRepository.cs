using Personal_Library.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Personal_Library.LibraryManagement;

namespace Personal_Library
{
    internal class BookRepository
    {
        private LibraryManagement _library;
        public BookRepository()
        {
            _library = new LibraryManagement();
        }

        public void AddBook()
        {
            try
            {
                Books newBook = new Books();

                Console.WriteLine("Please enter your title book:");
                newBook.Title = Console.ReadLine();

                Console.WriteLine("Please enter author of the book:");
                newBook.Author = Console.ReadLine();

                Console.WriteLine("Enter a genre {1. Fantasy,2. ScienceFiction,3. Biography}");
                string input = Console.ReadLine();
                bool isValidGenre = ValidationCenter.GetValidGenre(input);
                Enum.TryParse(input, true, out Books.GenreType genre);
                newBook.Genre = genre;

                _library.AddBook(newBook);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"The {newBook.Title} is Added!");
                Console.WriteLine("Please enter a key");
                Console.ReadKey();
            }
            catch (Exception err)
            {
                Console.WriteLine($"There is a error: {err.Message}");
            }
        }

        public void RemoveBook()
        {
            try
            {
                List<Books> listBooks = _library.ListBook();

                Console.WriteLine("Please enter remove your title book?");
                string bookTitle = Console.ReadLine();

                Books removeBook = _library.SearchBook(bookTitle);

                if (ValidationCenter.IsBookValid(removeBook))
                {
                    _library.RemoveBook(removeBook);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Removed. Press any key to continue...");
                    Console.ResetColor();
                    Console.ReadKey();
                }
            }
            catch (Exception err)
            {
                Console.WriteLine($"There is a error: {err.Message}");
            }
        }

        public void SearchBook()
        {
            bool searchFlag = false;

            while (!searchFlag)
            {
                try
                {
                    Console.WriteLine("Enter your book title do you want it?");
                    string bookTitle = Console.ReadLine();

                    var searchBook = _library.SearchBook(bookTitle);

                    if (!ValidationCenter.IsBookValid(searchBook))
                    {
                        Console.WriteLine("Try again choose an option:\n1. search\n2. Go to menu\n3. Exit");

                        string inputOption = Console.ReadLine();
                        bool isValid = ValidationCenter.IsInputValid(inputOption);
                        Enum.TryParse(inputOption, true, out MySearchOption selectSearchOption);

                        switch (selectSearchOption)
                        {
                            case MySearchOption.SearchAgain:
                                break;
                            case MySearchOption.GoToMenu:
                                searchFlag = true;
                                break;
                            case MySearchOption.Exit:
                                Environment.Exit(0);
                                break;
                            default:
                                Console.WriteLine("Invalid option, please try again.");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Your title book is {searchBook.Title} and your author book is {searchBook.Author} and genre book is {searchBook.Genre} book");
                    }
                }
                catch (Exception err)
                {

                    Console.WriteLine($"There is a error: {err.Message}");
                }
            }
        }

        public void ListBook()
        {
            _library.ListBook();
            ReadyToOrder();
        }


        void ReadyToOrder()
        {
            try
            {
                Console.WriteLine("1. Go to menu\n2. Exit");

                int inputUser = Convert.ToInt16(Console.ReadLine());
                if (inputUser == 2)
                {
                    Environment.Exit(0);
                }
            }
            catch (Exception err)
            {
                Console.WriteLine($"There is a error: {err.Message}");
            }
        }

    }
}
