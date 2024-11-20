using Personal_Library.Entities;

namespace Personal_Library
{
    public static class ValidationCenter
    {
        internal static Books.GenreType? GetValidGenre()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Enter a genre {1. Fantasy,2. ScienceFiction,3. Biography}");
                    string input = Console.ReadLine();

                    if (Enum.TryParse(input, true, out Books.GenreType result))
                    {
                        return result;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input, please input correct genre");
                    }
                }
                catch (Exception err)
                {
                    Console.WriteLine($"There is a error: {err.Message}");
                }
            }
        }

        internal static MainMenu? IsValidInput()
        {
            while (true)
            {
                try
                {
                    if (Enum.TryParse(Console.ReadLine(), out MainMenu result))
                    {
                        return result;
                    }
                    else
                    {
                        Console.WriteLine("Please input correct number of menu");
                    }
                }
                catch (Exception err)
                {
                    Console.WriteLine($"There is a error: {err.Message}");
                }
            }
        }

        internal static SearchOption? IsInputValid()
        {
            while (true)
            {
                try
                {
                    if (Enum.TryParse(Console.ReadLine(), true, out SearchOption option))
                    {
                        return option;
                    }
                    else
                    {
                        Console.WriteLine("Please input correct number of search menu");
                    }
                }
                catch (Exception err)
                {
                    Console.WriteLine($"There is a error: {err.Message}");
                }
            }
        }

        internal static bool IsBookValid(Books book)
        {
            try
            {
                if (book != null)
                {
                    return true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("There is no book with this title.");
                    Console.ForegroundColor = ConsoleColor.White;
                    return false;
                }
            }
            catch (Exception err)
            {
                Console.WriteLine($"There is a error: {err.Message}");
                return false;
            }
        }
    }
}
