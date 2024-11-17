using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_Library.Entities
{
    internal class Books
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public GenreType Genre { get; set; }

        public enum GenreType
        {
            // Fiction Genres
            Fantasy,
            ScienceFiction,
            Mystery,
            Romance,
            Horror,
            Thriller,
            HistoricalFiction,
            Adventure,
            LiteraryFiction,
            Dystopian,

            // Non-Fiction Genres
            Biography,
            Autobiography,
            SelfHelp,
            History,
            Travel,
            Science,
            Philosophy,
            Business,
            TrueCrime,
            Cookbooks,
            Memoir,

            // Children's and YA Genres
            PictureBooks,
            MiddleGrade,
            YoungAdult,
            FairyTales,
            Educational
        }
    }


}
