using Microsoft.VisualBasic;
using Personal_Library.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_Library
{
    public static class ValidationCenter
    {
        internal static Books.GenreType GetValidGenre()
        {
            string genreInput;
            bool isValid = false;
            Books.GenreType genreResult = default;

            while (!isValid)
            {
                Console.WriteLine("Enter a genre {1. Fantasy,2. ScienceFiction,3. Biography}");
                genreInput = Console.ReadLine();

                if (Enum.TryParse(genreInput, true, out genreResult))
                {
                    isValid = true;
                }
                else
                {
                    Console.WriteLine("Your genre type is wronge");
                }
            }
            return genreResult;
        }
    }
}
