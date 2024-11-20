using Personal_Library.Entities;

namespace Personal_Library
{
    public static class ValidationCenter
    {
        internal static Books.GenreType? GetValidGenre()
        {
            while (true)
            {
                if (Enum.TryParse(Console.ReadLine(), true, out Books.GenreType result))
                {
                    return result;
                }
                else
                {
                    Console.WriteLine("Invalid input, please input correct genre");
                }
            }
        }

        internal static int GetUserSelection()
        {
            int result;
            while (!int.TryParse(Console.ReadLine(), out result))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }

            return result;
        }

        internal static MainMenu? IsValidInput()
        {
            while (true)
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
        }

        internal static SearchOption? IsInputValid()
        {
            while (true)
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
        }

        internal static bool IsBookValid(Books book)
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
    }
}
