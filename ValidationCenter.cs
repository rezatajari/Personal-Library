using Personal_Library.Entities;
using static Personal_Library.LibraryManagement;

namespace Personal_Library
{
    public static class ValidationCenter
    {
        internal static bool GetValidGenre(string input)
        {
            while (true)
            {
                try
                {
                    if (Enum.TryParse(input, true, out Books.GenreType result))
                    {
                        return true;
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

        internal static bool IsValidInput(string input)
        {
            while (true)
            {
                try
                {
                    if (Enum.TryParse(input, out MainMenu result))
                    {
                        return true;
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

        internal static bool IsInputValid(string input)
        {
            while (true)
            {
                try
                {
                    if (Enum.TryParse(input, true, out MySearchOption option))
                    {
                        return true;
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
