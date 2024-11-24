using Personal_Library;
using Personal_Library.Entities;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using static Personal_Library.Enums;
using static Personal_Library.LibraryManagement;

bool isValidMenu;
BookRepository bookRepo = new BookRepository();
bool exitApp = false;

while (!exitApp)
{
    Welcome();
    MainMenu selectMenu = SelectMenu();

    switch (selectMenu)
    {
        case MainMenu.Add:
            bookRepo.AddBook();
            break;
        case MainMenu.Remove:
            bookRepo.RemoveBook();
            break;
        case MainMenu.Search:
            bookRepo.SearchBook();
            break;
        case MainMenu.List:
            bookRepo.ListBook();
            break;
        case MainMenu.Exit:
            exitApp = true;
            break;
        default:
            Console.WriteLine("Please only enter number between 1 to 5");
            break;
    }
}

void Welcome()
{
    Console.Clear();
    Console.ResetColor();
    Console.WriteLine("Welcome to the Personal Library Management System");
}
MainMenu SelectMenu()
{
    while (true)
    {
        ShowMenu();
        if (ChoiceEnterMenu(out MainMenu result))
        {
            return result;
        }
    }
}

static bool ChoiceEnterMenu(out MainMenu result)
{
    result = default;
    string input = Console.ReadLine();
    bool inputValid = ValidationCenter.IsValidInput(input);

    if (inputValid && Enum.TryParse(input, out result))
    {
        return true;
    }

    return false;
}

void ShowMenu()
{
    Console.ResetColor();
    Console.WriteLine("1. Add a Book\n2. Remove a Book\n3. Search for a Book\n4. List All Books\n5. Exit\r\nEnter your choice:");
}


//TODO: What’s Important for the Next Section:
//      As you move forward, you might consider the following topics to enhance your library system:
//1.    Persistence: Saving the books to a file or database (e.g., SQLite or MySQL).
//2.	Advanced Validation: Handling more complex validations, such as ensuring that book titles are unique.
//3.	User Interface: Moving from the console interface to a more user-friendly GUI, possibly using WPF (Windows Presentation Foundation) or ASP.NET Core for web-based applications.
//4.	Error Handling: Ensure your application handles different types of errors (e.g., invalid input, file read/write errors) gracefully.
//5.	Unit Testing: Implement unit tests for your methods to ensure they behave as expected.