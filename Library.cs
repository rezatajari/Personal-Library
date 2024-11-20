using Personal_Library.Entities;

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

            Console.WriteLine("Enter a genre {1. Fantasy,2. ScienceFiction,3. Biography}");
            newBook.Genre = (Books.GenreType)ValidationCenter.GetValidGenre();

            _bookList.Add(newBook);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Add book is Done!");
            Thread.Sleep(500);
        }

        public void RemoveBook()
        {
            var removeBook = SearchBook();
            if (ValidationCenter.IsBookValid(removeBook))
            {
                _bookList.Remove(removeBook);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Removed. Press any key to continue...");
                Console.ResetColor();
                Console.ReadKey();

            }
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

        public Books? SearchBook()
        {
            bool searchFlag = false;
            while (!searchFlag)
            {
                Console.WriteLine("What is book title do you want it?");
                string bookName = Console.ReadLine();
                var searchBook = _bookList.Find(b => b.Title.Equals(bookName, StringComparison.OrdinalIgnoreCase));

                if (!ValidationCenter.IsBookValid(searchBook))
                {
                    Console.WriteLine("Try again choose an option:\n1. search\n2. Go to menu\n3. Exit");

                    SearchOption? selectOption = (SearchOption?)ValidationCenter.IsInputValid();

                    switch (selectOption)
                    {
                        case SearchOption.SearchAgain:
                            break;
                        case SearchOption.GoToMenu:
                            searchFlag = true;
                            break;
                        case SearchOption.Exit:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Invalid option, please try again.");
                            break;
                    }
                }
                else
                {
                    return searchBook;
                }
            }
            return null;
        }

        public enum SearchOption
        {
            SearchAgain = 1,
            GoToMenu = 2,
            Exit = 3
        }
    }
}
