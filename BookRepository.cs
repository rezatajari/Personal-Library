using Personal_Library.Entities;
using static Personal_Library.Enums;
using static Personal_Library.LibraryService;

namespace Personal_Library
{
    internal class BookRepository
    {
        private LibraryService _library;
        public BookRepository(LibraryService library)
        {
            _library = library;
        }

        public void AddBook()
        {
            try
            {
                Books newBook = PerformBook();
                _library.AddBook(newBook);

                ResultAddBookMessage(newBook.Title);
            }
            catch (Exception err)
            {
                Console.WriteLine($"There is a error: {err.Message}");
            }
        }

        private void ResultAddBookMessage(string title)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"The {title} is Added!");
            Console.ResetColor();
            Console.WriteLine("Please enter a key");
            Console.ReadKey();
        }

        private Books PerformBook()
        {
            Books newBook = new Books();

            newBook.Title = GetTitle();
            newBook.Author = GetAuthor();
            newBook.Genre = GetGenre();

            return newBook;
        }

        private string GetAuthor()
        {
            Console.WriteLine("Please enter author of the book:");
            return Console.ReadLine();
        }

        private string GetTitle()
        {
            Console.WriteLine("Please enter your title book:");
            return Console.ReadLine();
        }

        public Books.GenreType GetGenre()
        {
            Console.WriteLine("Enter a genre {1. Fantasy,2. ScienceFiction,3. Biography}");
            string input = Console.ReadLine();
            bool isValidGenre = ValidationCenter.GetValidGenre(input);
            Enum.TryParse(input, true, out Books.GenreType genre);
            return genre;
        }

        public void RemoveBook()
        {
            try
            {
                Books getBook = GetBook();

                bool isBookValid = CheckBookValid(getBook);
                if (isBookValid)
                {
                    _library.RemoveBook(getBook);
                    RemoveConfirmMessage();
                }
            }
            catch (Exception err)
            {
                Console.WriteLine($"There is a error: {err.Message}");
            }
        }

        private bool CheckBookValid(Books book)
        {
            return ValidationCenter.IsBookValid(book);
        }

        private void RemoveConfirmMessage()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Removed. Press any key to continue...");
            Console.ResetColor();
            Console.ReadKey();
        }

        private Books GetBook()
        {
            List<Books> listBooks = _library.ListBook();

            Console.WriteLine("Please enter remove your title book?");
            string bookTitle = Console.ReadLine();

            return _library.SearchBook(bookTitle);
        }

        public void SearchBook()
        {
            bool searchFlag = false;

            while (!searchFlag)
            {
                try
                {
                    Books book = SearchByTitle();
                    bool isBookValid = CheckBookValid(book);

                    if (isBookValid)
                    {
                        Console.WriteLine($"Your title book is {book.Title} and your author book is {book.Author} and genre book is {book.Genre} book");
                    }
                    else
                    {
                        Console.WriteLine("Try again choose an option:\n1. search\n2. Go to menu\n3. Exit");

                        SelectSearchMenu(ref searchFlag);
                    }
                }
                catch (Exception err)
                {

                    Console.WriteLine($"There is a error: {err.Message}");
                }
            }
        }

        private static void SelectSearchMenu(ref bool searchFlag)
        {
            if (!Enum.TryParse(Console.ReadLine(), true, out MySearchOption
                          selectSearchOption) || !ValidationCenter.IsInputValid(selectSearchOption.ToString()))
            {
                Console.WriteLine("Invalid option, please try again.");
                return;
            }

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
            }
        }

        private Books SearchByTitle()
        {
            Console.WriteLine("Enter your book title do you want it?");
            string bookTitle = Console.ReadLine();
            return _library.SearchBook(bookTitle);
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
