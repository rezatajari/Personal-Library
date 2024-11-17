
using System.Diagnostics;

int selectOption;
WelcomeApp();





void WelcomeApp()
{
    Console.WriteLine("Welcome to the Personal Library Management System");
    Console.WriteLine("1. Add a Book\n2. Remove a Book\n3. Search for a Book\n4. List All Books\n5. Save and Exit\r\nEnter your choice:");

    selectOption = Convert.ToInt16(Console.ReadLine());
}


switch (selectOption)
{
    case 1:
        AddBook();
        break;
    case 2:
        RemoveBook();
        break;
    case 3:
        SearchBook();
        break;
    case 4:
        ListBook();
        break;
    case 5:
        break;
    default:
        Console.WriteLine("Please only enter number between 1 to 5");
        break;
}

void AddBook()
{
}

void ListBook()
{
}

void SearchBook()
{
}

void RemoveBook()
{
}

