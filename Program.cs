using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
    bool inputValid = ValidationCenter.MainValidInput(input);

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
