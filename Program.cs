using Personal_Library;

MainMenu? selectOption;
LibraryManagement library = new LibraryManagement();
bool exitApp = false;

while (!exitApp)
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("Welcome to the Personal Library Management System");
    Console.WriteLine("1. Add a Book\n2. Remove a Book\n3. Search for a Book\n4. List All Books\n5. Exit\r\nEnter your choice:");

    selectOption = ValidationCenter.IsValidInput();

    switch (selectOption)
    {
        case MainMenu.Add:
            library.AddBook();
            break;
        case MainMenu.Remove:
            library.RemoveBook();
            break;
        case MainMenu.Search:
            library.SearchBook();
            break;
        case MainMenu.List:
            library.ListBook();
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



