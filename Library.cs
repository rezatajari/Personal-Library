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

        public void AddBook(Books newBook)
        {
            _bookList.Add(newBook);
        }

        public void RemoveBook(Books removeBook)
        {
            _bookList.Remove(removeBook);
        }

        public List<Books> ListBook()
        {

            Console.WriteLine(new string('=', 55));
            Console.WriteLine("{0,-20} {1,-20} {2,-15}", "Title", "Author", "Genre");
            Console.WriteLine(new string('-', 55));

            foreach (Books book in _bookList)
            {
                Console.WriteLine("{0,-20} {1,-20} {2,-15}", book.Title, book.Author, book.Genre);
            }

            Console.WriteLine(new string('=', 55));

            return _bookList;
        }

        public Books? SearchBook(string bookTitle)
        {
            return _bookList.Find(b => b.Title.Equals(bookTitle, StringComparison.OrdinalIgnoreCase));
        }

        public enum MySearchOption
        {
            SearchAgain = 1,
            GoToMenu = 2,
            Exit = 3
        }
    }
}
