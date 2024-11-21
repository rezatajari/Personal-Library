using Personal_Library;
using Personal_Library.Entities;
using static Personal_Library.LibraryManagement;
using static Personal_Library.ValidationCenter;

bool isValidMenu;
LibraryManagement library = new LibraryManagement();
bool exitApp = false;

while (!exitApp)
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("Welcome to the Personal Library Management System");
    Console.WriteLine("1. Add a Book\n2. Remove a Book\n3. Search for a Book\n4. List All Books\n5. Exit\r\nEnter your choice:");

    string selectMenu = Console.ReadLine();
    isValidMenu = ValidationCenter.IsValidInput(selectMenu);
    Enum.TryParse(selectMenu, true, out MainMenu selectOption);

    switch (selectOption)
    {
        case MainMenu.Add:
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

                library.AddBook(newBook);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"The {newBook.Title} is Added!");
                Console.WriteLine("Please enter a key");
                Console.ReadKey();
            }
            catch (Exception err)
            {

                Console.WriteLine($"There is a error: {err.Message}");
            }

            break;
        case MainMenu.Remove:
            try
            {
                List<Books> listBooks = library.ListBook();

                Console.WriteLine("Please enter remove your title book?");
                string bookTitle = Console.ReadLine();

                Books removeBook = library.SearchBook(bookTitle);

                if (ValidationCenter.IsBookValid(removeBook))
                {
                    library.RemoveBook(removeBook);
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
            break;
        case MainMenu.Search:
            bool searchFlag = false;
            while (!searchFlag)
            {
                try
                {
                    Console.WriteLine("Enter your book title do you want it?");
                    string bookTitle = Console.ReadLine();

                    var searchBook = library.SearchBook(bookTitle);

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
            break;
        case MainMenu.List:
            library.ListBook();
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
            break;
        case MainMenu.Exit:
            exitApp = true;
            break;
        default:
            Console.WriteLine("Please only enter number between 1 to 5");
            break;
    }


}
public enum MainMenu
{
    Add = 1,
    Remove = 2,
    Search = 3,
    List = 4,
    Exit = 5
}


