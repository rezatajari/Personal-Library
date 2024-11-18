using Personal_Library;

int selectOption;
LibraryManagement library = new LibraryManagement();
bool exitApp = false;

while (!exitApp)
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("Welcome to the Personal Library Management System");
    Console.WriteLine("1. Add a Book\n2. Remove a Book\n3. Search for a Book\n4. List All Books\n5. Exit\r\nEnter your choice:");

    selectOption = Convert.ToInt16(Console.ReadLine());


    switch (selectOption)
    {
        case 1:
            library.AddBook();
            break;
        case 2:
            library.RemoveBook();
            break;
        case 3:
            library.SearchBook();
            break;
        case 4:
            library.ListBook();
            break;
        case 5:
            exitApp = true;
            break;
        default:
            Console.WriteLine("Please only enter number between 1 to 5");
            break;
    }
}




