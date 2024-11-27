using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Personal_Library;
using static Personal_Library.Enums;


var configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .Build();

// Set up DI container
var serviceCollection = new ServiceCollection();
ConfigureServices(serviceCollection, configuration);

// Build the service provider
var serviceProvider = serviceCollection.BuildServiceProvider();

var bookRepository = serviceProvider.GetService<BookRepository>();

static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
{
    var connectionString = configuration.GetConnectionString("LibraryDB");
    services.AddDbContext<LibraryDB>(options =>
        options.UseSqlServer(connectionString));
    services.AddTransient<LibraryService>();
    services.AddTransient<BookRepository>();
}

bool exitApp = false;

while (!exitApp)
{
    Welcome();
    MainMenu selectMenu = SelectMenu();

    switch (selectMenu)
    {
        case MainMenu.Add:
            bookRepository.AddBook();
            break;
        case MainMenu.Remove:
            bookRepository.RemoveBook();
            break;
        case MainMenu.Search:
            bookRepository.SearchBook();
            break;
        case MainMenu.List:
            bookRepository.ListBook();
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

//2.	Advanced Validation: Handling more complex validations, such as ensuring that book titles are unique.
//3.	User Interface: Moving from the console interface to a more user-friendly GUI, possibly using WPF (Windows Presentation Foundation) or ASP.NET Core for web-based applications.
//4.	Error Handling: Ensure your application handles different types of errors (e.g., invalid input, file read/write errors) gracefully.
//5.	Unit Testing: Implement unit tests for your methods to ensure they behave as expected.



//TODO: sql


//CRUD Operations: Implement CRUD(Create, Read, Update, Delete) operations for book management, interacting with the database instead of an in-memory list.
