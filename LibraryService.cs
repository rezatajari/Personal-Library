using Personal_Library.Entities;

namespace Personal_Library
{
    internal class LibraryService
    {
        private readonly LibraryDB _libraryDB;
        public LibraryService()
        {
            
        }
        internal LibraryService(LibraryDB libraryDB)
        {
            _libraryDB = libraryDB;
        }

        public void AddBook(Books newBook)
        {
            _libraryDB.Add(newBook);
        }

        public void RemoveBook(Books removeBook)
        {
            _libraryDB.Remove(removeBook);
        }

        public List<Books> ListBook()
        {

            Console.WriteLine(new string('=', 55));
            Console.WriteLine("{0,-20} {1,-20} {2,-15}", "Title", "Author", "Genre");
            Console.WriteLine(new string('-', 55));

            foreach (Books book in _libraryDB.Books)
            {
                Console.WriteLine("{0,-20} {1,-20} {2,-15}", book.Title, book.Author, book.Genre);
            }

            Console.WriteLine(new string('=', 55));

            return _libraryDB.Books.ToList();
        }

        public Books? SearchBook(string bookTitle)
        {
            List<Books> bookList = _libraryDB.Books.ToList();
            return bookList.Find(b => b.Title.Equals(bookTitle, StringComparison.OrdinalIgnoreCase));
        }
    }
}
